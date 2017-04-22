using System;
using I8Beef.Denon.Commands;

namespace I8Beef.Denon.Events
{
    /// <summary>
    /// Command event args class.
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandEventArgs"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public CommandEventArgs(Command command)
        {
            Command = command;
        }

        /// <summary>
        /// The <see cref="Command"/>.
        /// </summary>
        public Command Command { get; private set; }
    }
}
