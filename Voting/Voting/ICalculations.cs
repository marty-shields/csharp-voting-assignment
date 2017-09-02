using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public interface ICalculations
    {
        int CalculatePartyTotalVotes(Party party);
        Candidate CalculateElectedCandidates(Constituency constituency);
        IEnumerable<Candidate> SortCandidatesAlphabetically(Party party);
        IEnumerable<Party> SortPartyByVotes(PartyList partyList);
        List<Party> SortPartyAlphabetically(PartyList partyList);
        Party CalculatePartyWinner(PartyList partyList);
    }
}
