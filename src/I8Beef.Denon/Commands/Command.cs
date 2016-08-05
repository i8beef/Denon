using System.Collections.Generic;

namespace I8Beef.Denon.Commands
{
    public abstract class Command
    {
        public abstract string Setting { get; }
        public string Value { get; set; }
        public abstract List<string> ValidValues { get; } 
    }
}
