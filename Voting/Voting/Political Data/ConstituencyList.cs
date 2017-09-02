using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class ConstituencyList
    {
        public List<Constituency> constituencys { get; set; }

        public ConstituencyList()
        {
            constituencys = new List<Constituency>();
        }
    }
}
