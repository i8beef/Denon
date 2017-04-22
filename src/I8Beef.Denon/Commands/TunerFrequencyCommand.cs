using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon TunerFrequency command class.
    /// </summary>
    public class TunerFrequencyCommand : Command
    {
        /// <inheritdoc/>
        public override string Code { get { return "TFAN"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^TFAN(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new TunerFrequencyCommand { Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            if (int.TryParse(Value, out int intVal))
                return $"MainZone/index.put.asp?cmd0=PutTunerFrequencySet/{intVal}&cmd1=aspMainZone_WebUpdateStatus%2F&ZoneName=MAIN+ZONE";

            var val = Value;
            if (val == "UP")
                val = ">";
            else if (val == "DOWN")
                val = "<";

            return $"MainZone/index.put.asp?cmd0=PutTunerFrequencyBtn/{Value}&cmd1=aspMainZone_WebUpdateStatus%2F&ZoneName=MAIN+ZONE";
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
