using System;

namespace I8Beef.Denon.Events
{
    /// <summary>
    /// MessageSent event args class.
    /// </summary>
    public class MessageSentEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSentEventArgs"/> class.
        /// </summary>
        /// <param name="message">The sent message.</param>
        public MessageSentEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Sent message.
        /// </summary>
        public string Message { get; private set; }
    }
}
