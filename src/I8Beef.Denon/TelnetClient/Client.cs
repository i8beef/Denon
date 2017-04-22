using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Denon.Commands;
using I8Beef.Denon.Events;
using I8Beef.Denon.Exceptions;

namespace I8Beef.Denon.TelnetClient
{
    /// <summary>
    /// Telnet implementation of Denon <see cref="IClient"/>.
    /// </summary>
    public class Client : IClient
    {
        // A lookup to correlate request and responses
        private readonly IDictionary<string, TaskCompletionSource<Command>> _resultTaskCompletionSources = new ConcurrentDictionary<string, TaskCompletionSource<Command>>();

        private readonly object _writeLock = new object();
        private bool _disposed;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private string _host;
        private TcpClient _client;
        private NetworkStream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">Host address for HTTP client.</param>
        public Client(string host)
        {
            _host = host;
        }

        /// <inheritdoc/>
        public event EventHandler<ErrorEventArgs> Error;

        /// <inheritdoc/>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <inheritdoc/>
        public event EventHandler<MessageSentEventArgs> MessageSent;

        /// <inheritdoc/>
        public event EventHandler<CommandEventArgs> EventReceived;

        /// <summary>
        /// Connected.
        /// </summary>
        public bool Connected { get; private set; }

        /// <inheritdoc/>
        public async Task SendCommandAsync(Command command)
        {
            await FireAndForgetAsync(command).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Command> SendQueryAsync(Command command)
        {
            return await RequestResponseAsync(command).ConfigureAwait(false);
        }

        /// <summary>
        /// Listens for incoming XML stanzas and raises the appropriate events.
        /// </summary>
        /// <remarks>This runs in the context of a separate thread. In case of an
        /// exception, the Error event is raised and the thread is shutdown.</remarks>
        private void ReadStream()
        {
            try
            {
                using (var reader = new StreamReader(_stream))
                {
                    while (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var message = reader.ReadLine();
                        MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));

                        // Parse message
                        var command = CommandFactory.GetCommand(message);
                        if (command != null)
                        {
                            if (_resultTaskCompletionSources.TryGetValue(command.Code, out TaskCompletionSource<Command> resultTaskCompletionSource))
                            {
                                // query response
                                resultTaskCompletionSource.TrySetResult(command);
                                _resultTaskCompletionSources.Remove(command.Code);
                            }
                            else
                            {
                                // event
                                EventReceived?.Invoke(this, new CommandEventArgs(command));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Happens naturally on Dispose()
                if (e is IOException)
                {
                    Connected = false;
                }

                // An exception outside of Dispose should be raised to the caller to handle
                if (!_disposed)
                {
                    Error?.Invoke(this, new ErrorEventArgs(e));
                }
            }
        }

        /// <summary>
        /// Send a message without waiting for response.
        /// </summary>
        /// <param name="command">The message to be sent.</param>
        /// <param name="timeout">Time to wait for an error response.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task FireAndForgetAsync(Command command, int timeout = 50)
        {
            // Heartbeat check
            if (!Connected)
                throw new ConnectionException("Connection already closed or not authenticated");

            // Prepare the TaskCompletionSource, which is used to await the result
            var resultTaskCompletionSource = new TaskCompletionSource<Command>();
            if (!_resultTaskCompletionSources.ContainsKey(command.Code))
            {
                _resultTaskCompletionSources[command.Code] = resultTaskCompletionSource;

                // Start the sending
                Send(command.GetTelnetCommand());

                // Await, to make sure there wasn't an error
                var task = await Task.WhenAny(resultTaskCompletionSource.Task, Task.Delay(timeout)).ConfigureAwait(false);

                // Remove the result task, as we no longer need it.
                _resultTaskCompletionSources.Remove(command.Code);

                // This makes sure the exception, if there was one, is unwrapped
                await task;
            }
        }

        /// <summary>
        /// Sends a request response message.
        /// </summary>
        /// <param name="command">The message to be sent.</param>
        /// <param name="timeout">Timeout for the response, exception thrown on expiration.</param>
        /// <returns>Response message.</returns>
        private async Task<Command> RequestResponseAsync(Command command, int timeout = 2000)
        {
            if (!Connected)
                throw new ConnectionException("Connection already closed or not authenticated");

            // Prepate the TaskCompletionSource, which is used to await the result
            var resultTaskCompletionSource = new TaskCompletionSource<Command>();
            if (!_resultTaskCompletionSources.ContainsKey(command.Code))
            {
                _resultTaskCompletionSources[command.Code] = resultTaskCompletionSource;

                // Create the action which is called when a timeout occurs
                Action timeoutAction = () =>
                {
                    _resultTaskCompletionSources.Remove(command.Code);
                    resultTaskCompletionSource.TrySetException(new TimeoutException($"Timeout while waiting on response {command.Code} after {timeout}"));
                };

                Send(command.GetTelnetCommand());

                // Handle timeout
                var cancellationTokenSource = new CancellationTokenSource(timeout);
                using (cancellationTokenSource.Token.Register(timeoutAction))
                {
                    // Await until response or timeout
                    return await resultTaskCompletionSource.Task.ConfigureAwait(false);
                }
            }

            return null;
        }

        /// <summary>
        /// Sends the specified string to the server.
        /// </summary>
        /// <remarks>
        /// Do not use this method directly except for stream initialization and closing.
        /// </remarks>
        /// <param name="message">The string to send.</param>
        /// <exception cref="ArgumentNullException">The xml parameter is null.</exception>
        /// <exception cref="IOException">There was a failure while writing to the network.</exception>
        private void Send(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            // Attach carriage return character if not present
            if (!message.EndsWith("\r"))
                message += "\r";

            byte[] buf = Encoding.ASCII.GetBytes(message);
            lock (_writeLock)
            {
                try
                {
                    _stream.Write(buf, 0, buf.Length);
                    MessageSent?.Invoke(this, new MessageSentEventArgs(message));
                }
                catch
                {
                    Connected = false;
                    throw;
                }
            }
        }

        #region Connection management

        /// <summary>
        /// Connect to Denon.
        /// </summary>
        public void Connect()
        {
            // Establish a connection
            if (_client == null)
                _client = new TcpClient(_host, 23);

            // Get stream handle
            if (_stream == null)
                _stream = _client.GetStream();

            // Set up the listener task after authentication has been handled
            Task.Factory.StartNew(ReadStream, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            Connected = true;
        }

        /// <summary>
        /// Allows for explicit closing of session.
        /// </summary>
        public void Close()
        {
            // Stop parsing incoming feed
            _cancellationTokenSource.Cancel();

            // Dispose of stream
            if (_stream != null)
                _stream.Dispose();

            Connected = false;

            // Disconnect socket
            if (_client != null)
            {
                _client.Close();
                _client = null;
            }
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
                    _cancellationTokenSource.Dispose();
                }
            }
        }

        #endregion
    }
}
