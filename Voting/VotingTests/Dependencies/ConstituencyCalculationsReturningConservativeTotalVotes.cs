using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;

namespace VotingTests.Dependencies
{
    class ConstituencyCalculationsReturningConservativeTotalVotes : ICalculations
    {
        //we will not use the party which is being passed through although we will have to stillbring through a party
        public int CalculatePartyTotalVotes(Party party)
        {
            //return the correct value for conservative
            return 721;
        }
        #region these are dummies so it is ok to pass through null for these
        public Candidate CalculateElectedCandidates(Constituency constituency)
        {
            return null;
        }
        public IEnumerable<Candidate> SortCandidatesAlphabetically(Party party)
        {
            return null;
        }
        public IEnumerable<Party> SortPartyByVotes(PartyList partyList)
        {
            return null;
        }
        public List<Party> SortPartyAlphabetically(PartyList partyList)
        {
            return null;
        }
        public Party CalculatePartyWinner(PartyList partyList)
        {
            return null;
        }
        #endregion
    }
}
