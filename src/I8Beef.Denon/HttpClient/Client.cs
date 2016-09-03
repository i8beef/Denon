﻿using I8Beef.Denon.Commands;
using I8Beef.Denon.Entities;
using I8Beef.Denon.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace I8Beef.Denon.HttpClient
{
    public class Client : IClient
    {
        private bool _disposed;
        private string _host;

        private MainStatus _status;

        private Timer _refresh;
        private int _refreshInterval;

        public Client(string host, int refreshInterval = 30000)
        {
            _host = host;
            _refreshInterval = refreshInterval;
        }

        /// <summary>
        /// Connected.
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        /// The event that is raised when an unrecoverable error condition occurs.
        /// </summary>
        public event EventHandler<ErrorEventArgs> Error;

        /// <summary>
        /// The event that is raised when messages are received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event that is raised when messages are sent.
        /// </summary>
        public event EventHandler<MessageSentEventArgs> MessageSent;

        /// <summary>
        /// The event that is raised when and event is received from the Denon unit.
        /// </summary>
        public event EventHandler<DenonMessage> EventReceived;

        /// <summary>
        /// Send command to the Denon.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Awaitable Task.</returns>
        public async Task SendCommandAsync(string command)
        {
            // TODO: Parse the command
            var arguments = "";

            // Make call
            await FireAndForgetAsync(command, arguments).ConfigureAwait(false);
        }

        /// <summary>
        /// Send command to the Denon.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>The response.</returns>
        public async Task<DenonMessage> SendQueryAsync(string command)
        {
            // TODO: Parse the command
            var arguments = "";

            return new DenonMessage();
        }

        #region Denon Queries

        /// <summary>
        /// Gets device info.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <returns></returns>
        private async Task<Schema.DeviceInfo.Device_Info> GetDenonDeviceInfo()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/Deviceinfo.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync();
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
        /// <returns></returns>
        private async Task<Schema.Status.Item> GetDenonStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/formMainZone_MainZoneXml.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync();
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
        /// <returns></returns>
        private async Task<Schema.MainZoneStatus.Item> GetDenonMainZoneStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/goform/formMainZone_MainZoneXmlStatus.xml";
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync();
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
        /// <returns></returns>
        private async Task<IDictionary<int, Schema.SecondaryZoneStatus.Item>> GetAllDenonSecondaryZonesStatus(int zoneCount = 1)
        {
            var result = new Dictionary<int, Schema.SecondaryZoneStatus.Item>();
            for (var i = 2; i <= zoneCount + 1; i++)
            {
                result.Add(i, await GetDenonSecondaryZonesStatus(i));
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
        /// <returns></returns>
        private async Task<Schema.SecondaryZoneStatus.Item> GetDenonSecondaryZonesStatus(int zoneId)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + string.Format("/goform/formZone{0}_Zone{0}XmlStatusLite.xml", zoneId);
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync();
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
        /// <param name="argument">Arguments to be used in command format.</param>
        /// <returns></returns>
        private async Task FireAndForgetAsync(string command, params string[] arguments)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = "http://" + _host + "/" + string.Format(command, arguments);
                var response = await client.GetAsync(request).ConfigureAwait(false);
                MessageSent?.Invoke(this, new MessageSentEventArgs(request));

                var responseString = await response.Content.ReadAsStringAsync();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshAsync(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Make all of the calls to get current status
                var status = new MainStatus();

                var mainZoneStatusTask = GetDenonMainZoneStatus();
                var secondaryZoneStatusTask = GetAllDenonSecondaryZonesStatus(1);
                await Task.WhenAll(mainZoneStatusTask, secondaryZoneStatusTask);

                var mainZoneStatus = await mainZoneStatusTask;
                var secondaryZoneStatus = await secondaryZoneStatusTask;

                status.Power = mainZoneStatus.Power.Value.ToUpper() == "ON";
                status.Volume = 80 + decimal.Parse(mainZoneStatus.MasterVolume.Value);
                status.Mute = mainZoneStatus.Mute.Value.ToUpper() == "ON";
                status.Input = mainZoneStatus.InputFuncSelect.Value;
                status.SurroundMode = mainZoneStatus.SurrMode.Value;

                foreach (var zone in secondaryZoneStatus)
                {
                    status.SecondaryZoneStatus.Add("ZONE" + zone.Key, new StatusLite
                    {
                        Power = zone.Value.Power.Value.ToUpper() == "ON",
                        Volume = 80 + decimal.Parse(zone.Value.MasterVolume.Value),
                        Mute = zone.Value.Mute.Value.ToUpper() == "ON",
                        Input = zone.Value.InputFuncSelect.Value
                    });
                }

                // Compare to current cached status
                var updates = CompareStatusObjects(_status, status);

                // If updated, publish changes
                if (updates.Count > 0)
                {
                    foreach (var update in updates)
                    {
                        EventReceived?.Invoke(this, update);
                    }

                    _status = status;
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new ErrorEventArgs(ex));
                Timer timer = (Timer)sender;
                timer.Stop();
            }
        }

        /// <summary>
        /// Compares twomaster state objects.
        /// </summary>
        /// <param name="status1">First status.</param>
        /// <param name="status2">Second status.</param>
        /// <returns>List of changes.</returns>
        private IList<DenonMessage> CompareStatusObjects(MainStatus status1, MainStatus status2)
        {
            var updates = new List<DenonMessage>();

            // Power: PW
            if (status1.Power != status2.Power)
                updates.Add(new DenonMessage { Code = "PW", Parameter = status2.Power ? "ON" : "OFF", Value = status2.Power ? "ON" : "OFF" });

            // Volume: MV
            if (status1.Volume != status2.Volume)
                updates.Add(new DenonMessage { Code = "MV", Parameter = status2.Volume.ToString(), Value = status2.Volume.ToString() });

            // Mute: MU
            if (status1.Mute != status2.Mute)
                updates.Add(new DenonMessage { Code = "MU", Parameter = status2.Mute ? "ON" : "OFF", Value = status2.Mute ? "ON" : "OFF" });

            // Input: SI
            if (status1.Input != status2.Input)
                updates.Add(new DenonMessage { Code = "SI", Parameter = status2.Input, Value = status2.Input });

            // Surround mode: MS
            if (status1.SurroundMode != status2.SurroundMode)
                updates.Add(new DenonMessage { Code = "MS", Parameter = status2.SurroundMode, Value = status2.SurroundMode });

            foreach (var zone in status1.SecondaryZoneStatus)
            {
                var zoneNumber = zone.Key.Substring(4);

                // Zone power: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Power != status2.SecondaryZoneStatus[zone.Key].Power)
                    updates.Add(new DenonMessage { Code = $"Z{zoneNumber}", Parameter = status2.SecondaryZoneStatus[zone.Key].Power ? "ON" : "OFF", Value = status2.SecondaryZoneStatus[zone.Key].Power ? "ON" : "OFF" });

                // Zone input: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Input != status2.SecondaryZoneStatus[zone.Key].Input)
                    updates.Add(new DenonMessage { Code = $"Z{zoneNumber}", Parameter = status2.SecondaryZoneStatus[zone.Key].Input, Value = status2.SecondaryZoneStatus[zone.Key].Input });

                // Zone volume: Z#
                if (status1.SecondaryZoneStatus[zone.Key].Volume != status2.SecondaryZoneStatus[zone.Key].Volume)
                    updates.Add(new DenonMessage { Code = $"Z{zoneNumber}", Parameter = status2.SecondaryZoneStatus[zone.Key].Volume.ToString(), Value = status2.SecondaryZoneStatus[zone.Key].Volume.ToString() });

                // Zone input: Z#MU
                if (status1.SecondaryZoneStatus[zone.Key].Mute != status2.SecondaryZoneStatus[zone.Key].Mute)
                    updates.Add(new DenonMessage { Code = $"Z{zoneNumber}MU", Parameter = status2.SecondaryZoneStatus[zone.Key].Mute ? "ON" : "OFF", Value = status2.SecondaryZoneStatus[zone.Key].Mute ? "ON" : "OFF" });
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
		/// Releases all resources used by the current instance of the XmppIm
		/// class, optionally disposing of managed resource.
		/// </summary>
		/// <param name="disposing">true to dispose of managed resources, otherwise
		/// false.</param>
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