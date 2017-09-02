using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class ConstiuencyCalculations : ICalculations
    {
        public int totalVotes { get; set; }

        //method to return the total votes for each party
        public int CalculatePartyTotalVotes(Party party)
        {
            totalVotes = 0;
            foreach(Candidate candidate in party.CandidateList) //looks through each candidate and add the number of votes to total votes
            {
                totalVotes += candidate.votes;
            }

            return totalVotes; //return the final amount
        }

        //take the candidates from the constituency and use a linq query to order them by the number of votes
        public Candidate CalculateElectedCandidates(Constituency constituency)
        {
            //make a query ordering by votes
            Candidate candidateQuery = (from candidate in constituency.candidates
                                                    orderby candidate.votes descending
                                                    select candidate).First();
            //return found candidate
            return (Candidate)candidateQuery;
        }

        //ordering candidates in the parties alphabetically
        public IEnumerable<Candidate> SortCandidatesAlphabetically(Party party)
        {
            IEnumerable<Candidate> candidateAlthabeticallyQuery = from candidate in party.CandidateList
                                                          orderby candidate.firstName
                                                          select candidate;

            return candidateAlthabeticallyQuery;
        }

        //ordering the party by the amount of votes they have
        public IEnumerable<Party> SortPartyByVotes(PartyList partyList)
        {
            IEnumerable<Party> partyByVotesQuery = from party in partyList.partys
                                                          orderby party.totalVotes descending
                                                          select party;

            return partyByVotesQuery;
        }

        //ordering the parties alphabetically
        public List<Party> SortPartyAlphabetically(PartyList partyList)
        {
            var partyAlthabeticallyQuery = from party in partyList.partys
                                                          orderby party.partyName
                                                          select party;

            return partyAlthabeticallyQuery.ToList();
        }

        //function to calculate the party with the most votes
        public Party CalculatePartyWinner(PartyList partyList)
        {
            Party partyByVotesQuery = (from party in partyList.partys
                                                   orderby party.totalVotes descending
                                                   select party).First();

            return (Party)partyByVotesQuery;
        }
    }
}
