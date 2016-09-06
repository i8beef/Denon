using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class MenuCommand : Command
    {
        private IDictionary<string, string> _commandLookup = new Dictionary<string, string>
        {
            { "CUP", "CurUp" },
            { "CDN", "CurDown" },
            { "CLT", "CurLeft" },
            { "CRT", "CurRight" }
        };

        public override string Code {  get { return "MN"; } }

        public override string GetHttpCommand()
        {
            if (!_commandLookup.ContainsKey(Value))
                throw new ArgumentException("Unsupported value: " + Value);

            var val = _commandLookup[Value];

            return $"MainZone/index.put.asp?cmd0=PutNetAudioCommand/{Value}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=MAIN+ZONE";
        }

        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }

        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^MN(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new MenuCommand { Value = value };
        }
    }
}
