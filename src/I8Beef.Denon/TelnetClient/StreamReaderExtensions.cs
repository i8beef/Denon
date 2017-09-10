using System.IO;
using System.Text;

namespace I8Beef.Denon.TelnetClient
{
    /// <summary>
    /// StreamReader extensions.
    /// </summary>
    public static class StreamReaderExtensions
    {
        /// <summary>
        /// Reads line up to a single line break. Note that this is to get around the default StreamReader.ReadLine not
        /// seeming to actually break after a single '\r' in all cases for some reason.
        /// </summary>
        /// <param name="self">Stream reader.</param>
        /// <returns>Read line.</returns>
        public static string ReadLineSingleBreak(this StreamReader self)
        {
            StringBuilder currentLine = new StringBuilder();
            int i;
            char c;
            while ((i = self.Read()) >= 0)
            {
                c = (char)i;
                if (c == '\r'
                    || c == '\n')
                {
                    break;
                }

                currentLine.Append(c);
            }

            return currentLine.ToString();
        }
    }
}
