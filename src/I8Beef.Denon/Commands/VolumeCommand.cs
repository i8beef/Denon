using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class VolumeCommand : Command
    {
        public override string Code { get { return "MV"; } }

        public override string GetHttpCommand()
        {
            int intVal;
            if (int.TryParse(Value, out intVal))
                return $"MainZone/index.put.asp?cmd0=PutMasterVolumeSet/{(intVal - 80)}";

            var val = Value;
            if (val == "UP")
                val = ">";
            else if (val == "DOWN")
                val = "<";

            return $"MainZone/index.put.asp?cmd0=PutMasterVolumeBtn/{val}";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^MV(UP|DOWN|\d+|\?)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new VolumeCommand { Value = value };
        }
    }
}
