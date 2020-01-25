using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;
using I8Beef.Denon.HttpClient.Schema.DeviceInfo;

namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// Denon HTTP client.
    /// </summary>
    public interface IDenonHttpClient
    {
        /// <summary>
        /// The event that is raised when messages are received.
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event that is raised when messages are sent.
        /// </summary>
        event EventHandler<MessageSentEventArgs> MessageSent;

        /// <summary>
        /// Sends specified command to the device.
        /// </summary>
        /// <param name="command">The command URL to execute (unformatted)</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task FireAndForgetAsync(Command command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all secondary zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="zoneCount">Number of secondary zones to try and fetch (default 1).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IDictionary<int, Schema.SecondaryZoneStatus.Item>> GetAllDenonSecondaryZonesStatusAsync(int zoneCount = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets device info.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Device_Info> GetDenonDeviceInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets main zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Schema.MainZoneStatus.Item> GetDenonMainZoneStatusAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets secondary zone status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="zoneId">Zone ID to fetch status for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Schema.SecondaryZoneStatus.Item> GetDenonSecondaryZonesStatusAsync(int zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the main device status.
        /// </summary>
        /// <remarks>
        /// Returns the actual deserialized XML object from the Denon unit.
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Schema.Status.Item> GetDenonStatusAsync(CancellationToken cancellationToken = default);
    }
}