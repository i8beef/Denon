namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon ZoneCommand abstract class.
    /// </summary>
    public abstract class ZoneCommand : Command
    {
        /// <summary>
        /// Denon command Zone Id.
        /// </summary>
        public int ZoneId { get; set; }
    }
}
