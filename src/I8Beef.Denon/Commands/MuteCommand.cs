using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon Mute command class.
    /// </summary>
    public class MuteCommand : Command
    {
        /// <inheritdoc/>
        public override string Code { get { return "MU"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^MU(ON|OFF|\?)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new MuteCommand { Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            return $"MainZone/index.put.asp?cmd0=PutVolumeMute/{Value}&cmd1=aspMainZone_WebUpdateStatus/";
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
