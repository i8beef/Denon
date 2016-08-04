using I8Beef.Denon.Schema;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace I8Beef.Denon
{
    public class Client
    {
        private string _host;

        public Client(string host)
        {
            _host = host;
        }

        public async Task<Item> GetStatus(bool zone2)
        {
            using (var client = new HttpClient())
            {
                var command = zone2 ? "/goform/formMainZone_MainZoneXml.xml?_=&ZoneName=ZONE2" : "/goform/formMainZone_MainZoneXml.xml";
                var response = await client.GetAsync("http://" + _host + command);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Item>.Deserialize(responseString);
            }
        }

        public async Task SendCommand(string command, string argument)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://" + _host +"/" + string.Format(command, argument));
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);
            }
        }
    }
}
