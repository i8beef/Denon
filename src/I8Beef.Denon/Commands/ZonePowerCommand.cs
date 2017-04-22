using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon ZonePower command class.
    /// </summary>
    public class ZonePowerCommand : ZoneCommand
    {
        /// <inheritdoc/>
        public override string Code { get { return $"Z{ZoneId}"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^Z(\d)(ON|OFF|\?)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[2].Value;

            return new ZonePowerCommand { ZoneId = int.Parse(matches.Groups[1].Value), Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            if (ZoneId != 0)
                return $"MainZone/index.put.asp?cmd0=PutZone_OnOff/{Value}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=ZONE{ZoneId}";
            else
                return $"MainZone/index.put.asp?cmd0=PutZone_OnOff/{Value}&cmd1=aspMainZone_WebUpdateStatus/";
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
