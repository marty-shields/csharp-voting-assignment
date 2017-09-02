using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class Candidate
    {
        //variables for the input data for candidate
        public string partyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int votes { get; set; }

        //constructor to create a candidate object with the required fields
        public Candidate(string partyName, string firstName, string lastName, int votes)
        {
            this.partyName = partyName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.votes = votes;
        }

        //overide string to show nicer display
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
