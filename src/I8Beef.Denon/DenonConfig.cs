using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8Beef.Denon
{
    public class DenonConfig
    {
        public DenonConfig()
        {
            InputMappings = new Dictionary<string, string>();
        }

        public int NumberOfZones { get; set; }

        public IDictionary<string, string> InputMappings { get; set; }
    }
}
