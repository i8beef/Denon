using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    public class CommandFactory
    {
        public static Command GetCommand(string commandString)
        {
            if (commandString.StartsWith("PW"))
                return PowerCommand.Parse(commandString);

            if (commandString.StartsWith("MV"))
            {
                if (commandString.StartsWith("MVMAX"))
                    return null;

                return VolumeCommand.Parse(commandString);
            }

            if (commandString.StartsWith("MU"))
                return MuteCommand.Parse(commandString);

            if (commandString.StartsWith("SI"))
                return InputCommand.Parse(commandString);

            if (commandString.StartsWith("MS"))
                return SurroundModeCommand.Parse(commandString);

            if (commandString.StartsWith("TFAN"))
                return TunerFrequencyCommand.Parse(commandString);

            if (commandString.StartsWith("TMAN"))
                return TunerModeCommand.Parse(commandString);

            if (commandString.StartsWith("Z"))
            {
                if (Regex.Match(commandString, @"^Z\d(ON|OFF|\?)$").Success)
                    return ZonePowerCommand.Parse(commandString);

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
