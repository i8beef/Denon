﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;

namespace I8Beef.Denon
{
    /// <summary>
    /// Denon client interface.
    /// </summary>
    public interface IClient : IDisposable
    {
        /// <summary>
        /// The event that is raised when an unrecoverable error condition occurs.
        /// </summary>
        event EventHandler<ErrorEventArgs> Error;

        /// <summary>
        /// The event that is raised when messages are received.
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event that is raised when messages are sent.
        /// </summary>
        event EventHandler<MessageSentEventArgs> MessageSent;

        /// <summary>
        /// The event that is raised when and event is received from the Denon unit.
        /// </summary>
        event EventHandler<CommandEventArgs> EventReceived;

        /// <summary>
        /// Send command to the Denon.
        /// </summary>
        /// <param name="command">The <see cref="Command"/> to send.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable Task.</returns>
        Task SendCommandAsync(Command command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send command to the Denon.
        /// </summary>
        /// <param name="command">The <see cref="Command"/> to send.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The response.</returns>
        Task<Command> SendQueryAsync(Command command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Connect to Denon.
        /// </summary>
        void Connect();

        /// <summary>
        /// Allows for explicit closing of session.
        /// </summary>
        void Close();
    }
}
