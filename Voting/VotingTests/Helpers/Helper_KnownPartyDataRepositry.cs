using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;

namespace VotingTests.Helpers
{
    public static class Helper_KnownPartyDataRepositry
    {
        public static Party GetKnownPartyConservative(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Conservative", new Candidate("Conservative", "Martin", "Shields", 311));

            party.CandidateList.Add(new Candidate("Conservative", "Helen", "Bowmer", 210));
            party.CandidateList.Add(new Candidate("Conservative", "Amy", "Mcdowell", 200));

            //erturn the party when done with the list
            return party;
        }

        public static Party GetKnownPartyLabour(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Labour", new Candidate("Labour", "Henry", "Olson", 200));

            party.CandidateList.Add(new Candidate("Labour", "Tom", "Smith", 100));

            //erturn the party when done with the list
            return party;
        }
        public static Party GetKnownPartyLibDem(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Lib Dem", new Candidate("Lib Dem", "Rachael", "Stevens", 150));

            //get candidate details and add each candidate to the party
            //loop to take each contituency
            party.CandidateList.Add(new Candidate("Lib Dem", "Ryan", "Turner", 120));
            party.CandidateList.Add(new Candidate("Lib Dem", "Karren", "Lattimer", 110));

            //erturn the party when done with the list
            return party;
        }
        public static Party GetKnownPartyGreen(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Green", new Candidate("Green", "Lauren", "Story", 50));

            //get candidate details and add each candidate to the party
            //loop to take each contituency
            party.CandidateList.Add(new Candidate("Green", "Danielle", "Brady", 190));

            //erturn the party when done with the list
            return party;
        }

        public static Party GetKnownPartySinnFein(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Sinn Fein", new Candidate("Sinn Fein", "Michael", "Ingle", 120));

            //get candidate details and add each candidate to the party
            //loop to take each contituency

            //erturn the party when done with the list
            return party;
        }

        public static Party GetKnownPartyScottishNationalParty(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Scottish National Party", new Candidate("Scottish National Party", "Paul", "Smith", 100));

            //erturn the party when done with the list
            return party;
        }

        public static Party GetKnownPartyPlaidCymru(ConstituencyList constituencyList)
        {
            //create a party object with all the details
            var party = new Party("Plaid Cymru", new Candidate("Plaid Cymru", "Oscar", "Montgomary", 180));

            //get candidate details and add each candidate to the party
            //loop to take each contituency

            //erturn the party when done with the list
            return party;
        }
    }
}
