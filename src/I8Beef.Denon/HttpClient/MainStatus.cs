using System.Collections.Generic;

namespace I8Beef.Denon.HttpClient
{
    /// <summary>
    /// Main status class.
    /// </summary>
    internal class MainStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainStatus"/> class.
        /// </summary>
        public MainStatus()
        {
            SecondaryZoneStatus = new Dictionary<string, StatusLite>();
        }

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

        /// <summary>
        /// SurroundMode status.
        /// </summary>
        public string SurroundMode { get; set; }

        /// <summary>
        /// Secondary zone status.
        /// </summary>
        public IDictionary<string, StatusLite> SecondaryZoneStatus { get; set; }
    }
}
