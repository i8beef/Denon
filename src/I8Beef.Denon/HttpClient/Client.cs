using I8Beef.Denon.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I8Beef.Denon.HttpClient
{
    public class Client
    {
        private string _host;

        public Client(string host)
        {
            _host = host;
        }

        /// <summary>
        /// Gets an object representing the current main status settings.
        /// </summary>
        /// <returns></returns>
        public async Task<MainStatus> GetStatus(int numberOfZones = 2)
        {
            var status = new MainStatus();

            var mainZoneStatusTask = GetDenonMainZoneStatus();
            var secondaryZoneStatusTask = GetAllDenonSecondaryZonesStatus(numberOfZones - 1);
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

            return status;
        }

        /// <summary>
        /// Gets device info.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <returns></returns>
        public async Task<Schema.DeviceInfo.Device_Info> GetDenonDeviceInfo()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/goform/Deviceinfo.xml").ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
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
        public async Task<Schema.Status.Item> GetDenonStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/goform/formMainZone_MainZoneXml.xml").ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
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
        public async Task<Schema.MainZoneStatus.Item> GetDenonMainZoneStatus()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/goform/formMainZone_MainZoneXmlStatus.xml").ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
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
        public async Task<IDictionary<int, Schema.SecondaryZoneStatus.Item>> GetAllDenonSecondaryZonesStatus(int zoneCount = 1)
        {
            var result = new Dictionary<int, Schema.SecondaryZoneStatus.Item> ();
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
        public async Task<Schema.SecondaryZoneStatus.Item> GetDenonSecondaryZonesStatus(int zoneId)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + string.Format("/goform/formZone{0}_Zone{0}XmlStatusLite.xml", zoneId)).ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
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
        public async Task SendCommand(string command, params string[] arguments)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/" + string.Format(command, arguments));
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);
            }
        }
    }
}
