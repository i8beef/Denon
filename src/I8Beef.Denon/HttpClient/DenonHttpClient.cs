using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;

namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// Denon HTTP client.
    /// </summary>
    public class DenonHttpClient : IDenonHttpClient
    {
        private static readonly System.Net.Http.HttpClient _httpClient = new System.Net.Http.HttpClient();
        private readonly string _host;

        /// <summary>
        /// Initializes a new instance of the <see cref="DenonHttpClient"/> class.
        /// </summary>
        /// <param name="host">Host address for HTTP client.</param>
        public DenonHttpClient(string host)
        {
            _host = host;
        }

        /// <inheritdoc/>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <inheritdoc/>
        public event EventHandler<MessageSentEventArgs> MessageSent;

        /// <inheritdoc/>
        public async Task<Schema.DeviceInfo.Device_Info> GetDenonDeviceInfoAsync(CancellationToken cancellationToken = default)
        {
            var request = "http://" + _host + "/goform/Deviceinfo.xml";
            var response = await _httpClient.GetAsync(request, cancellationToken)
                .ConfigureAwait(false);
            MessageSent?.Invoke(this, new MessageSentEventArgs(request));

            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Invalid status code received: " + response.StatusCode);

            return XmlSerializer<Schema.DeviceInfo.Device_Info>.Deserialize(responseString);
        }

        /// <inheritdoc/>
        public async Task<Schema.Status.Item> GetDenonStatusAsync(CancellationToken cancellationToken = default)
        {
            var request = "http://" + _host + "/goform/formMainZone_MainZoneXml.xml";
            var response = await _httpClient.GetAsync(request, cancellationToken)
                .ConfigureAwait(false);
            MessageSent?.Invoke(this, new MessageSentEventArgs(request));

            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Invalid status code received: " + response.StatusCode);

            return XmlSerializer<Schema.Status.Item>.Deserialize(responseString);
        }

        /// <inheritdoc/>
        public async Task<Schema.MainZoneStatus.Item> GetDenonMainZoneStatusAsync(CancellationToken cancellationToken = default)
        {
            var request = "http://" + _host + "/goform/formMainZone_MainZoneXmlStatus.xml";
            var response = await _httpClient.GetAsync(request, cancellationToken)
                .ConfigureAwait(false);
            MessageSent?.Invoke(this, new MessageSentEventArgs(request));

            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Invalid status code received: " + response.StatusCode);

            return XmlSerializer<Schema.MainZoneStatus.Item>.Deserialize(responseString);
        }

        /// <inheritdoc/>
        public async Task<IDictionary<int, Schema.SecondaryZoneStatus.Item>> GetAllDenonSecondaryZonesStatusAsync(int zoneCount = 1, CancellationToken cancellationToken = default)
        {
            var result = new Dictionary<int, Schema.SecondaryZoneStatus.Item>();
            for (var i = 2; i <= zoneCount + 1; i++)
            {
                result.Add(i, await GetDenonSecondaryZonesStatusAsync(i, cancellationToken).ConfigureAwait(false));
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<Schema.SecondaryZoneStatus.Item> GetDenonSecondaryZonesStatusAsync(int zoneId, CancellationToken cancellationToken = default)
        {
            var request = "http://" + _host + string.Format("/goform/formZone{0}_Zone{0}XmlStatusLite.xml", zoneId);
            var response = await _httpClient.GetAsync(request, cancellationToken)
                .ConfigureAwait(false);
            MessageSent?.Invoke(this, new MessageSentEventArgs(request));

            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Invalid status code received: " + response.StatusCode);

            return XmlSerializer<Schema.SecondaryZoneStatus.Item>.Deserialize(responseString);
        }

        /// <inheritdoc/>
        public async Task FireAndForgetAsync(Command command, CancellationToken cancellationToken = default)
        {
            var request = "http://" + _host + "/" + string.Format(command.GetHttpCommand());
            var response = await _httpClient.GetAsync(request, cancellationToken)
                .ConfigureAwait(false);
            MessageSent?.Invoke(this, new MessageSentEventArgs(request));

            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(responseString));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Invalid status code received: " + response.StatusCode);
        }
    }
}
