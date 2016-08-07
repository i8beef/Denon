using System.Collections.Generic;

namespace I8Beef.Denon.Entities
{
    public class StatusLite
    {
        public bool Power { get; set; }
        public decimal Volume { get; set; }
        public bool Mute { get; set; }
        public string Input { get; set; }
    }
}
