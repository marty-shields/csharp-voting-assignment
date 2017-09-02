using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class Party
    {
        public string partyName { get; set; }
        public int totalVotes { get; set; } // total votes will be calculated and added as needed

        private List<Candidate> candidateList = new List<Candidate>(); //list of candidates in that party
        public List<Candidate> CandidateList
        {
            get
            {
                return candidateList;
            }

            set
            {
                candidateList = value;
            }
        } // getter and setter for the candidate list



        //constructor so that we can ctreate a party object with just the name for now
        public Party(string partyName, Candidate candidate)
        {
            this.partyName = partyName;
            this.totalVotes = 0;
            this.candidateList.Add(candidate);
        }

        public override string ToString()
        {
            return String.Format("{0,-25}{1,5}",partyName,totalVotes);
        }
    }
}
