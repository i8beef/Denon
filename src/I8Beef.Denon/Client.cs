using I8Beef.Denon.Schema;
using I8Beef.Denon.Schema.DeviceInfo;
using I8Beef.Denon.Schema.Status;
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

        public async Task<Device_Info> GetDeviceInfo()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/goform/Deviceinfo.xml").ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<Device_Info>.Deserialize(responseString);
            }
        }

        public async Task<item> GetStatus()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://" + _host + "/goform/formMainZone_MainZoneXmlStatus.xml").ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Invalid status code received: " + response.StatusCode);

                return XmlSerializer<item>.Deserialize(responseString);
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
