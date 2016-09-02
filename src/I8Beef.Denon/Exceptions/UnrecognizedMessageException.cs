using System;

namespace I8Beef.Denon.Exceptions
{
    public class UnrecognizedMessageException : Exception
    {
        public UnrecognizedMessageException()
        {
        }

        public UnrecognizedMessageException(string message)
        : base(message)
        {
        }

        public UnrecognizedMessageException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
