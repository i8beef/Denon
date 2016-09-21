using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class ZoneVolumeCommand : ZoneCommand
    {
        public override string Code { get { return $"Z{ZoneId}"; } }

        public override string GetHttpCommand()
        {
            int intVal;
            if (int.TryParse(Value, out intVal))
                if (ZoneId != 0)
                    return $"MainZone/index.put.asp?cmd0=PutMasterVolumeSet/{(intVal - 80)}&cmd1=aspMainZone_WebUpdateStatus/&ZONE{ZoneId}";
                else
                    return $"MainZone/index.put.asp?cmd0=PutMasterVolumeSet/{(intVal - 80)}";

            var val = Value;
            if (val == "UP")
                val = ">";
            else if (val == "DOWN")
                val = "<";

            if (ZoneId != 0)
                return $"MainZone/index.put.asp?cmd0=PutMasterVolumeBtn/{val}&ZONE{ZoneId}";
            else
                return $"MainZone/index.put.asp?cmd0=PutMasterVolumeBtn/{val}";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value.Replace(".", "")}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^Z(\d)(UP|DOWN|\d\d\d?)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[2].Value;

            if (value.Length == 3)
                value = value.Substring(0, 2) + "." + value.Substring(2, 1);

            return new ZoneVolumeCommand { ZoneId = int.Parse(matches.Groups[1].Value), Value = value };
        }
    }
}
