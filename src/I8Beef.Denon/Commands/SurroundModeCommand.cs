using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class SurroundModeCommand : Command
    {
        public override string Code { get { return "MS"; } }

        public override string GetHttpCommand()
        {
            return $"MainZone/index.put.asp?cmd0=PutSurroundMode/{Value}";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^MS(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new SurroundModeCommand { Value = value };
        }
    }
}
