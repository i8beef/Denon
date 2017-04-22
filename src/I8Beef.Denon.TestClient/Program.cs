using System;
using System.Threading.Tasks;
using I8Beef.Denon.Commands;

namespace I8Beef.Denon.TestClient
{
    /// <summary>
    /// Main entry point for test program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for test program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            Task.Run(async () => await MainAsync(args)).Wait();
        }

        /// <summary>
        /// Main entry point for test program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task MainAsync(string[] args)
        {
            var host = "192.168.1.117";

            Console.Write("Use (H)TTP client or (T)CP client? ");
            var clientType = Console.ReadKey().KeyChar;
            Console.WriteLine();

            using (var client = GetClient(clientType, host))
            {
                /*
                client.MessageSent += (o, e) => { Console.WriteLine("Message sent: " + e.Message); };
                client.MessageReceived += (o, e) => { Console.WriteLine("Message received: " + e.Message); };
                */
                client.EventReceived += (o, e) => { Console.WriteLine($"Event received: {e.GetType()} {e.Command.Code} {e.Command.Value}"); };

                client.Connect();

                var commandString = string.Empty;
                while (commandString != "exit")
                {
                    if (!string.IsNullOrEmpty(commandString))
                    {
                        var command = CommandFactory.GetCommand(commandString);
                        if (command != null)
                        {
                            if (commandString.EndsWith("?"))
                            {
                                var response = await client.SendQueryAsync(command);
                                Console.WriteLine($"New value for {response.GetType()}: {response.Value}");
                            }
                            else
                            {
                                await client.SendCommandAsync(command);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Command not recognized");
                        }
                    }

                    Console.Write("Enter command: ");
                    commandString = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Gets the requested <see cref="IClient"/> implementation.
        /// </summary>
        /// <param name="type">The type command line parameter.</param>
        /// <param name="host">The host to connect to.</param>
        /// <returns>A <see cref="IClient"/> implementation.</returns>
        private static IClient GetClient(char type, string host)
        {
            if (type == 'h')
                return new HttpClient.Client(host);
            else
                return new TelnetClient.Client(host);
        }
    }
}
