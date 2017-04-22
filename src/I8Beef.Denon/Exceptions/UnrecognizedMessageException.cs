using System;

namespace I8Beef.Denon.Exceptions
{
    /// <summary>
    /// UnrecognizedMessage exception.
    /// </summary>
    [Serializable]
    public class UnrecognizedMessageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnrecognizedMessageException"/> class.
        /// </summary>
        public UnrecognizedMessageException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnrecognizedMessageException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public UnrecognizedMessageException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnrecognizedMessageException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner <see cref="Exception"/>.</param>
        public UnrecognizedMessageException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
