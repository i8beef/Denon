using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon TunerMode command class.
    /// </summary>
    public class TunerModeCommand : Command
    {
        /// <inheritdoc/>
        public override string Code { get { return "TMAN"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^TMAN(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new TunerModeCommand { Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            if (Value == "AUTO" || Value == "OFF")
                return $"MainZone/index.put.asp?cmd0=PutTunerAuto/{Value}&ZoneName=MAIN+ZONE";

            if (Value == "AM" || Value == "FM")
                return $"MainZone/index.put.asp?cmd0=PutTunerBand/{Value}&ZoneName=MAIN+ZONE";

            throw new ArgumentException("Unsupported value: " + Value);
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
