using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class TunerFrequencyCommand : Command
    {
        public override string Code { get { return "TFAN"; } }

        public override string GetHttpCommand()
        {
            int intVal;
            if (int.TryParse(Value, out intVal))
                return $"MainZone/index.put.asp?cmd0=PutTunerFrequencySet/{intVal}&cmd1=aspMainZone_WebUpdateStatus%2F&ZoneName=MAIN+ZONE";

            var val = Value;
            if (val == "UP")
                val = ">";
            else if (val == "DOWN")
                val = "<";

            return $"MainZone/index.put.asp?cmd0=PutTunerFrequencyBtn/{Value}&cmd1=aspMainZone_WebUpdateStatus%2F&ZoneName=MAIN+ZONE";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^TFAN(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new SurroundModeCommand { Value = value };
        }
    }
}
