using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class ZoneInputCommand : ZoneCommand
    {
        public override string Code { get { return $"Z{ZoneId}"; } }

        public override string GetHttpCommand()
        {
            if (ZoneId != 0)
                return $"MainZone/index.put.asp?cmd0=PutZone_InputFunction/{Value}&cmd1=aspMainZone_WebUpdateStatus/&ZONE{ZoneId}";
            else
                return $"MainZone/index.put.asp?cmd0=PutZone_InputFunction/{Value}&cmd1=aspMainZone_WebUpdateStatus/";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^Z(\d)(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[2].Value;

            return new ZonePowerCommand { ZoneId = int.Parse(matches.Groups[1].Value), Value = value };
        }
    }
}
