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
            var currentLine = new StringBuilder();

            while (true)
            {
                var i = self.Read();

                if (i < 0)
                {
                    return currentLine.Length == 0 ? null : currentLine.ToString();
                }

                var c = (char)i;

                if (c == '\r' || c == '\n')
                {
                    return currentLine.ToString();
                }

                currentLine.Append(c);
            }
        }
    }
}
