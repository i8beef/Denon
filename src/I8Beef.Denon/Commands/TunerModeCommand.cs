using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class TunerModeCommand : Command
    {
        public override string Code { get { return "TMAN"; } }

        public override string GetHttpCommand()
        {
            if (Value == "AUTO" || Value == "OFF")
                return $"MainZone/index.put.asp?cmd0=PutTunerAuto/{Value}&ZoneName=MAIN+ZONE";

            if (Value == "AM" || Value == "FM")
                return $"MainZone/index.put.asp?cmd0=PutTunerBand/{Value}&ZoneName=MAIN+ZONE";

            throw new ArgumentException("Unsupported value: " + Value);
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^TMAN(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new SurroundModeCommand { Value = value };
        }
    }
}
