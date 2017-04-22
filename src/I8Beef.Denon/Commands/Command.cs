namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon Command abstract class.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Denon command code.
        /// </summary>
        public abstract string Code { get; }

        /// <summary>
        /// Denon command value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets the HTTP version of this command.
        /// </summary>
        /// <returns>The HTTP version of this command.</returns>
        public abstract string GetHttpCommand();

        /// <summary>
        /// Gets the telnet version of this command.
        /// </summary>
        /// <returns>The telnet version of this command.</returns>
        public abstract string GetTelnetCommand();
    }
}
