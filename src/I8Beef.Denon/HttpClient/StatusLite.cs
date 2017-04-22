namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// StatusLite class.
    /// </summary>
    internal class StatusLite
    {
        /// <summary>
        /// Power status.
        /// </summary>
        public bool Power { get; set; }

        /// <summary>
        /// Volume status.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Mute status.
        /// </summary>
        public bool Mute { get; set; }

        /// <summary>
        /// Input status.
        /// </summary>
        public string Input { get; set; }
    }
}
