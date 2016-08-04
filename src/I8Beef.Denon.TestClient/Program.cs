namespace I8Beef.Denon.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "192.168.1.117";

            var client = new Client(host);
            client.SendCommand(Commands.MainZoneInputSelect, "SAT").Wait();
        }
    }
}
