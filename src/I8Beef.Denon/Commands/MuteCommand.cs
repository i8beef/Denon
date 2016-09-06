using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class MuteCommand : Command
    {
        public override string Code { get { return "MU"; } }

        public override string GetHttpCommand()
        {
            return $"MainZone/index.put.asp?cmd0=PutVolumeMute/{Value}&cmd1=aspMainZone_WebUpdateStatus/";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^MU(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new MuteCommand { Value = value };
        }
    }
}
