using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class ConfigRecord
    {
            public String Filename { get; private set; }

            public ConfigRecord(String Filename)
            {
                this.Filename = Filename;
            }

            public override String ToString()
            {
                return String.Format("{0}", Filename);
            }

     }
}
