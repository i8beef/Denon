using System;

namespace I8Beef.Denon.Exceptions
{
    /// <summary>
    /// Connection exception.
    /// </summary>
    [Serializable]
    public class ConnectionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionException"/> class.
        /// </summary>
        public ConnectionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConnectionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner <see cref="Exception"/>.</param>
        public ConnectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
