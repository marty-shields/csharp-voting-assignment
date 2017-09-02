using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class Constituency
    {
        //variables for the list of candidates in a constituency and the name of constituency
        public string constituencyName { get; set; }
        public List<Candidate> candidates { get; set; }

        public Constituency(string constituencyName)
        {
            this.constituencyName = constituencyName;
        }

        public override string ToString()
        {
            return String.Format(constituencyName);
        }
    }
}
