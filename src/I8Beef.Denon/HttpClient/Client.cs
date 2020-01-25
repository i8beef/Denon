using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;
using Timer = System.Timers.Timer;

namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// HTTP implementation of Denon <see cref="IClient"/>.
    /// </summary>
    public class Client : IClient
    {
        private readonly IDenonHttpClient _httpClient;
        private readonly int _refreshInterval;

        private bool _disposed;
        private MainStatus _status;
        private Timer _refresh;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">Host address for HTTP client.</param>
        /// <param name="refreshInterval">Refresh interval for client.</param>
        public Client(string host, int refreshInterval = 30000)
        {
            _refreshInterval = refreshInterval;
            _httpClient = new DenonHttpClient(host);
            _httpClient.MessageReceived += MessageReceived;
            _httpClient.MessageSent += MessageSent;
        }

        /// <inheritdoc/>
        public event EventHandler<ErrorEventArgs> Error;

        /// <inheritdoc/>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <inheritdoc/>
        public event EventHandler<MessageSentEventArgs> MessageSent;

        /// <inheritdoc/>
        public event EventHandler<CommandEventArgs> EventReceived;

        /// <inheritdoc/>
        public Task SendCommandAsync(Command command, CancellationToken cancellationToken = default)
        {
            return _httpClient.FireAndForgetAsync(command, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Command> SendQueryAsync(Command command, CancellationToken cancellationToken = default)
        {
            if (_status == null)
                await RefreshStatusAsync(false).ConfigureAwait(false);

            if (command is PowerCommand)
                return new PowerCommand { Value = _status.Power ? "ON" : "OFF" };

            if (command is VolumeCommand)
                return new VolumeCommand { Value = _status.Volume.ToString() };

            if (command is MuteCommand)
                return new MuteCommand { Value = _status.Mute ? "ON" : "OFF" };

            if (command is InputCommand)
                return new InputCommand { Value = _status.Input };

            if (command is SurroundModeCommand)
                return new SurroundModeCommand { Value = _status.SurroundMode };

            /*
            if (command is TunerFrequencyCommand)
                return new TunerFrequencyCommand { Value = _status.Volume.ToString() };

            if (command is TunerModeCommand)
                return new TunerModeCommand { Value = _status.Volume.ToString() };
            */

            if (command is ZoneCommand zoneCommand)
            {
                if (command is ZonePowerCommand)
                    return new ZonePowerCommand { ZoneId = zoneCommand.ZoneId, Value = _status.SecondaryZoneStatus[$"ZONE{zoneCommand.ZoneId}"].Power ? "ON" : "OFF" };

                if (command is ZoneVolumeCommand)
                    return new ZoneVolumeCommand { ZoneId = zoneCommand.ZoneId, Value = _status.SecondaryZoneStatus[$"ZONE{zoneCommand.ZoneId}"].Volume.ToString() };

                if (command is ZoneMuteCommand)
                    return new ZoneMuteCommand { ZoneId = zoneCommand.ZoneId, Value = _status.SecondaryZoneStatus[$"ZONE{zoneCommand.ZoneId}"].Mute ? "ON" : "OFF" };

                if (command is ZoneInputCommand)
                    return new ZoneInputCommand { ZoneId = zoneCommand.ZoneId, Value = _status.SecondaryZoneStatus[$"ZONE{zoneCommand.ZoneId}"].Input };
            }

            return null;
        }

        #region Connection management

        /// <summary>
        /// Connect to Denon.
        /// </summary>
        public void Connect()
        {
            // Enable refresh
            if (_refresh != null)
                _refresh.Dispose();

            _refresh = new Timer();
            _refresh.Elapsed += RefreshAsync;
            _refresh.Interval = _refreshInterval;
            _refresh.Start();
        }

        /// <summary>
        /// Allows for explicit closing of session.
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// Heartbeat ping. Failure will result in the heartbeat being stopped, which will
        /// make any future calls throw an exception as the heartbeat indicator will be disabled.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e"><see cref="ElapsedEventArgs"/>.</param>
        private async void RefreshAsync(object sender, ElapsedEventArgs e)
        {
            try
            {
                await RefreshStatusAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new ErrorEventArgs(ex));
                Timer timer = (Timer)sender;
                timer.Stop();
            }
        }

        /// <summary>
        /// Refreshes the current Denon status.
        /// </summary>
        /// <param name="publishChanges">Indiactes if changes should be published or not.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task RefreshStatusAsync(bool publishChanges = false)
        {
            // Make all of the calls to get current status
            var status = new MainStatus();

            var mainZoneStatusTask = _httpClient.GetDenonMainZoneStatusAsync();
            var secondaryZoneStatusTask = _httpClient.GetAllDenonSecondaryZonesStatusAsync(1);
            await Task.WhenAll(mainZoneStatusTask, secondaryZoneStatusTask).ConfigureAwait(false);

            var mainZoneStatus = await mainZoneStatusTask.ConfigureAwait(false);
            var secondaryZoneStatus = await secondaryZoneStatusTask.ConfigureAwait(false);

            status.Power = mainZoneStatus.Power.Value.ToUpper() == "ON";
            status.Volume = 80 + decimal.Parse(mainZoneStatus.MasterVolume.Value);
            status.Mute = mainZoneStatus.Mute.Value.ToUpper() == "ON";
            status.Input = mainZoneStatus.InputFuncSelect.Value;
            status.SurroundMode = mainZoneStatus.SurrMode.Value;

            foreach (var zone in secondaryZoneStatus)
            {
                var statusLite = new StatusLite
                {
                    Power = zone.Value.Power.Value.ToUpper() == "ON",
                    Volume = 80 + decimal.Parse(zone.Value.MasterVolume.Value),
                    Mute = zone.Value.Mute.Value.ToUpper() == "ON",
                    Input = zone.Value.InputFuncSelect.Value
                };
                status.SecondaryZoneStatus.Add($"ZONE{zone.Key}", statusLite);
            }

            // Initialize state
            if (_status == null)
                _status = status;

            // Compare to current cached status
            var updates = CompareStatusObjects(_status, status);

            // If updated, publish changes
            if (publishChanges && updates.Count > 0)
            {
                foreach (var update in updates)
                {
                    EventReceived?.Invoke(this, new CommandEventArgs(update));
                }

                _status = status;
            }
        }

        /// <summary>
        /// Compares twomaster state objects.
        /// </summary>
        /// <param name="status1">First status.</param>
        /// <param name="status2">Second status.</param>
        /// <returns>List of changes.</returns>
        private IList<Command> CompareStatusObjects(MainStatus status1, MainStatus status2)
        {
            var updates = new List<Command>();

            // Power: PW
            if (status1.Power != status2.Power)
                updates.Add(new PowerCommand { Value = status2.Power ? "ON" : "OFF" });

            // Volume: MV
            if (status1.Volume != status2.Volume)
                updates.Add(new VolumeCommand { Value = status2.Volume.ToString() });

            // Mute: MU
            if (status1.Mute != status2.Mute)
                updates.Add(new MuteCommand { Value = status2.Mute ? "ON" : "OFF" });

            // Input: SI
            if (status1.Input != status2.Input)
                updates.Add(new InputCommand { Value = status2.Input });

            // Surround mode: MS
            if (status1.SurroundMode != status2.SurroundMode)
                updates.Add(new SurroundModeCommand { Value = status2.SurroundMode });

            foreach (var zone in status1.SecondaryZoneStatus)
            {
                var zoneNumber = int.Parse(zone.Key.Substring(4));

                // Zone power: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Power != status2.SecondaryZoneStatus[zone.Key].Power)
                    updates.Add(new ZonePowerCommand { ZoneId = zoneNumber, Value = status2.SecondaryZoneStatus[zone.Key].Power ? "ON" : "OFF" });

                // Zone input: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Input != status2.SecondaryZoneStatus[zone.Key].Input)
                    updates.Add(new ZoneInputCommand { ZoneId = zoneNumber, Value = status2.SecondaryZoneStatus[zone.Key].Input });

                // Zone volume: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Volume != status2.SecondaryZoneStatus[zone.Key].Volume)
                    updates.Add(new ZoneVolumeCommand { ZoneId = zoneNumber, Value = status2.SecondaryZoneStatus[zone.Key].Volume.ToString() });

                // Zone input: Z#MU
                if (status1.SecondaryZoneStatus[zone.Key].Mute != status2.SecondaryZoneStatus[zone.Key].Mute)
                    updates.Add(new ZoneMuteCommand { ZoneId = zoneNumber, Value = status2.SecondaryZoneStatus[zone.Key].Mute ? "ON" : "OFF" });
            }

            return updates;
        }

        #endregion

        #region IDisposable implementation

        /// <summary>
        /// Releases all resources used by the current instance of the XmppIm class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases all resources used by the current instance of the XmppIm class, optionally disposing of managed resource.
        /// </summary>
        /// <param name="disposing">true to dispose of managed resources, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // Get rid of managed resources.
                if (disposing)
                {
                    // Kill heartbeat
                    if (_refresh != null)
                    {
                        _refresh.Stop();
                        _refresh.Dispose();
                    }
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }

        #endregion
    }
}
