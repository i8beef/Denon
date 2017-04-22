using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;

namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// HTTP implementation of Denon <see cref="IClient"/>.
    /// </summary>
    public class Client : IClient
    {
        private bool _disposed;
        private string _host;

        private MainStatus _status;

        private Timer _refresh;
        private int _refreshInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">Host address for HTTP client.</param>
        /// <param name="refreshInterval">Refresh interval for client.</param>
        public Client(string host, int refreshInterval = 30000)
        {
            _host = host;
            _refreshInterval = refreshInterval;
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
        public bool Connected { get; private set; }

        /// <inheritdoc/>
        public async Task SendCommandAsync(Command command)
        {
            await FireAndForgetAsync(command).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Command> SendQueryAsync(Command command)
        {
            if (_status == null)
                await RefreshStatus().ConfigureAwait(false);

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

        #region Denon Queries

        /// <summary>
        /// Gets device info.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<Schema.DeviceInfo.Device_Info> GetDenonDeviceInfo()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/Deviceinfo.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Schema.DeviceInfo.Device_Info>.Deserialize(responseString);
            }
        }

        /// <summary>
        /// Gets the main device status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<Schema.Status.Item> GetDenonStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/formMainZone_MainZoneXml.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Schema.Status.Item>.Deserialize(responseString);
            }
        }

        /// <summary>
        /// Gets main zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<Schema.MainZoneStatus.Item> GetDenonMainZoneStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/formMainZone_MainZoneXmlStatus.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Schema.MainZoneStatus.Item>.Deserialize(responseString);
            }
        }

        /// <summary>
        /// Gets all secondary zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="zoneCount">Number of secondary zones to try and fetch (default 1).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<IDictionary<int, Schema.SecondaryZoneStatus.Item>> GetAllDenonSecondaryZonesStatus(int zoneCount = 1)
        {
            var result = new Dictionary<int, Schema.SecondaryZoneStatus.Item>();
            for (var i = 2; i <= zoneCount + 1; i++)
            {
                result.Add(i, await GetDenonSecondaryZonesStatus(i).ConfigureAwait(false));
            }

            return result;
        }

        /// <summary>
        /// Gets secondary zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="zoneId">Zone ID to fetch status for.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<Schema.SecondaryZoneStatus.Item> GetDenonSecondaryZonesStatus(int zoneId)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + string.Format("/goform/formZone{0}_Zone{0}XmlStatusLite.xml", zoneId);
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Schema.SecondaryZoneStatus.Item>.Deserialize(responseString);
            }
        }

        /// <summary>
        /// Sends specified command to the device.
        /// </summary>
        /// <param name="command">The command URL to execute (unformatted)</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task FireAndForgetAsync(Command command)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/" + string.Format(command.GetHttpCommand());
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);
            }
        }

        #endregion

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

            Connected = true;
        }

        /// <summary>
        /// Allows for explicit closing of session.
        /// </summary>
        public void Close()
        {
            if (Connected)
            {
                // Kill heartbeat
                if (_refresh != null)
                {
                    _refresh.Stop();
                    _refresh.Dispose();
                }

                Connected = false;
            }
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
                await RefreshStatus(true).ConfigureAwait(false);
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
        private async Task RefreshStatus(bool publishChanges = false)
        {
            // Make all of the calls to get current status
            var status = new MainStatus();

            var mainZoneStatusTask = GetDenonMainZoneStatus();
            var secondaryZoneStatusTask = GetAllDenonSecondaryZonesStatus(1);
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
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance of the XmppIm class, optionally disposing of managed resource.
        /// </summary>
        /// <param name="disposing">true to dispose of managed resources, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // Indicate that the instance has been disposed.
                _disposed = true;

                // Get rid of managed resources.
                if (disposing)
                {
                    Close();
                }
            }
        }

        #endregion
    }
}
