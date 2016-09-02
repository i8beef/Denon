using I8Beef.Denon.TelnetClient;
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

            using (var client = new Client(host))
            {
                client.MessageSent += (o, e) => { Console.WriteLine("Message sent: " + e.Message); };
                client.MessageReceived += (o, e) => { Console.WriteLine("Message received: " + e.Message); };
                client.EventReceived += (o, e) => { Console.WriteLine($"Event received: {e.Code} {e.Parameter} {e.Value}"); };

                client.Connect();

                var command = "";
                while (command != "exit")
                {
                    if (!string.IsNullOrEmpty(command))
                    {
                        if (command .EndsWith("?"))
                        {
                            var response = await client.SendQueryAsync(command);
                            Console.WriteLine($"New value for {response.Code} {response.Parameter}: {response.Value}");
                        }
                        else
                        {
                            await client.SendCommandAsync(command);
                        }
                    }

                    command = Console.ReadLine();
                }
            }
        }
    }
}
