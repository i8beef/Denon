using System.Collections.Generic;

namespace I8Beef.Denon.Entities
{
    public class MainStatus
    {
        public MainStatus()
        {
            SecondaryZoneStatus = new Dictionary<string, StatusLite>();
        }

        public bool Power { get; set; }
        public decimal Volume { get; set; }
        public bool Mute { get; set; }
        public string Input { get; set; }
        public string SurroundMode { get; set; }

        public IDictionary<string, StatusLite> SecondaryZoneStatus { get; set; }
    }
}
