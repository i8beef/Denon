using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class InputCommand : Command
    {
        public override string Code { get { return "SI"; } }

        public override string GetHttpCommand()
        {
            return $"MainZone/index.put.asp?cmd0=PutZone_InputFunction/{Value}&cmd1=aspMainZone_WebUpdateStatus/";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^SI(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new InputCommand { Value = value };
        }
    }
}
