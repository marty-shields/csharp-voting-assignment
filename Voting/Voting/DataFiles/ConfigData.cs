using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class ConfigData
    {
        public List<ConfigRecord> configRecords { get; set; }

        public int NextRecord { get; set; }

        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}
