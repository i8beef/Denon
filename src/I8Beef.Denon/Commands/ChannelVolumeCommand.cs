using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon Channel Volume command class.
    /// </summary>
    public class ChannelVolumeCommand : Command
    {
        /// <inheritdoc/>
        public override string Code { get { return "CV"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^CV(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new ChannelVolumeCommand { Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            throw new NotImplementedException("Channel volume controls not easily mapped to HTTP");
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
