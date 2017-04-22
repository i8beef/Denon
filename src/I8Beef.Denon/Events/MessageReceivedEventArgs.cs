using System;

namespace I8Beef.Denon.Events
{
    /// <summary>
    /// MessageReceived event args class.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="message">The received message.</param>
        public MessageReceivedEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Received message.
        /// </summary>
        public string Message { get; private set; }
    }
}
