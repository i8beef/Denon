using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Command factory class.
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Gets the <see cref="Command"/> encoded by given command string.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/> encoded by given command string.</returns>
        public static Command GetCommand(string commandString)
        {
            if (commandString.StartsWith("CV"))
                return ChannelVolumeCommand.Parse(commandString);

            if (commandString.StartsWith("DC"))
                return DigitalInputCommand.Parse(commandString);

            if (commandString.StartsWith("MS"))
                return SurroundModeCommand.Parse(commandString);

            if (commandString.StartsWith("MU"))
                return MuteCommand.Parse(commandString);

            if (commandString.StartsWith("MV"))
            {
                if (commandString.StartsWith("MVMAX"))
                    return null;

                return VolumeCommand.Parse(commandString);
            }

            if (commandString.StartsWith("PS"))
                return ParameterSettingCommand.Parse(commandString);

            if (commandString.StartsWith("PV"))
                return PictureCommand.Parse(commandString);

            if (commandString.StartsWith("PW"))
                return PowerCommand.Parse(commandString);

            if (commandString.StartsWith("SD"))
                return SignalModeCommand.Parse(commandString);

            if (commandString.StartsWith("SI"))
                return InputCommand.Parse(commandString);

            if (commandString.StartsWith("SLP"))
                return SleepCommand.Parse(commandString);

            if (commandString.StartsWith("SV"))
                return VideoSelectCommand.Parse(commandString);

            if (commandString.StartsWith("TFAN"))
                return TunerFrequencyCommand.Parse(commandString);

            if (commandString.StartsWith("TMAN"))
                return TunerModeCommand.Parse(commandString);

            if (commandString.StartsWith("VS"))
                return VideoSettingCommand.Parse(commandString);

            if (commandString.StartsWith("Z"))
            {
                if (Regex.Match(commandString, @"^Z\d(ON|OFF|\?)$").Success)
                    return ZonePowerCommand.Parse(commandString);

                if (Regex.Match(commandString, @"^ZM(ON|OFF|\?)$").Success)
                    return ZoneMainCommand.Parse(commandString);

                if (Regex.Match(commandString, @"^Z\d(UP|DOWN|\d\d)$").Success)
                    return ZoneVolumeCommand.Parse(commandString);

                if (Regex.Match(commandString, @"^Z\dMU(ON|OFF|\?)$").Success)
                    return ZoneMuteCommand.Parse(commandString);

                if (Regex.Match(commandString, @"^Z\d(.*)$").Success)
                    return ZoneInputCommand.Parse(commandString);
            }

            return null;
        }
    }
}
