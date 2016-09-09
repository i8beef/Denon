using I8Beef.Denon.Commands;
using System;
using System.Threading.Tasks;

namespace I8Beef.Denon.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await MainAsync(args)).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var host = "192.168.1.117";

            Console.Write("Use (H)TTP client or (T)CP client? ");
            var clientType = Console.ReadKey().KeyChar;
            Console.WriteLine();

            using (var client = GetClient(clientType, host))
            {
                //client.MessageSent += (o, e) => { Console.WriteLine("Message sent: " + e.Message); };
                //client.MessageReceived += (o, e) => { Console.WriteLine("Message received: " + e.Message); };
                client.EventReceived += (o, e) => { Console.WriteLine($"Event received: {e.GetType()} {e.Code} {e.Value}"); };

                client.Connect();

                var commandString = "";
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

        private static IClient GetClient(char type, string host)
        {
            if (type == 'h')
                return new HttpClient.Client(host);
            else
                return new TelnetClient.Client(host);
        }
    }
}
