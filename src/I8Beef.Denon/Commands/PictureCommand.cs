﻿using System;
using System.Text.RegularExpressions;

namespace I8Beef.Denon.Commands
{
    /// <summary>
    /// Denon Picture (mode etc.) command class.
    /// </summary>
    public class PictureCommand : Command
    {
        /// <inheritdoc/>
        public override string Code { get { return "PV"; } }

        /// <summary>
        /// Parses a commands string to return an instance of this <see cref="Command"/>.
        /// </summary>
        /// <param name="commandString">The command string to parse.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public static Command Parse(string commandString)
        {
            var matches = Regex.Match(commandString, @"^PV(.*)$");
            if (!matches.Success)
                throw new ArgumentException("Command string not recognized: " + commandString);

            var value = matches.Groups[1].Value;

            return new PictureCommand { Value = value };
        }

        /// <inheritdoc/>
        public override string GetHttpCommand()
        {
            throw new NotImplementedException("Picture controls not easily mapped to HTTP");
        }

        /// <inheritdoc/>
        public override string GetTelnetCommand()
        {
            return $"{Code}{Value}";
        }
    }
}
