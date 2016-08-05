using System.Collections.Generic;

namespace I8Beef.Denon.Commands
{
    public class StandBy : Command
    {
        private readonly List<string> _validValues = new List<string> { "STANDBY", "ON" };

        public override string Setting {  get { return "PutSystem_OnStandby"; } }
        public override List<string> ValidValues { get { return _validValues; } }
    }
}
