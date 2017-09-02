using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;

namespace VotingTests.Helpers
{
    /// <summary>
    /// Creating a helper so we can return constituency class objects in order to test. We are actually testing against coded examples
    /// </summary>
    public static class Helper_KnownConstituencyDataRepository
    {
        //creating returnable constituency
        public static Constituency GetKnownConstituency01()
        {
            //instanciate constituency class and add a list of candidates
            var constituency = new Constituency("Sunderland North");
            constituency.candidates = new List<Candidate>();

            //build a known list of candidates to add to the constituency
            constituency.candidates.Add(new Candidate("Conservative", "Martin", "Shields", 311));
            constituency.candidates.Add(new Candidate("Scottish National Party", "Paul", "Smith", 100));
            constituency.candidates.Add(new Candidate("Labour", "Henry", "Olson", 200));
            constituency.candidates.Add(new Candidate("Lib Dem", "Rachael", "Stevens", 150));

            //return the constituency
            return constituency;
        }

        //creating returnable constituency
        public static Constituency GetKnownConstituency03()
        {
            //instanciate constituency class and add a list of candidates
            var constituency = new Constituency("South Tyneside");
            constituency.candidates = new List<Candidate>();

            //build a known list of candidates to add to the constituency
            constituency.candidates.Add(new Candidate("Conservative", "Helen", "Bowmer", 210));
            constituency.candidates.Add(new Candidate("Green", "Lauren", "Story", 50));
            constituency.candidates.Add(new Candidate("Sinn Fein", "Michael", "Ingle", 120));
            constituency.candidates.Add(new Candidate("Plaid Cymru", "Oscar", "Montgomary", 180));
            constituency.candidates.Add(new Candidate("Lib Dem", "Ryan", "Turner", 120));

            //return the constituency
            return constituency;
        }

        //creating returnable constituency
        public static Constituency GetKnownConstituency05()
        {
            //instanciate constituency class and add a list of candidates
            var constituency = new Constituency("Duhram");
            constituency.candidates = new List<Candidate>();

            //build a known list of candidates to add to the constituency
            constituency.candidates.Add(new Candidate("Conservative", "Amy", "Mcdowell", 200));
            constituency.candidates.Add(new Candidate("Green", "Danielle", "Brady", 190));
            constituency.candidates.Add(new Candidate("Labour", "Tom", "Smith", 100));
            constituency.candidates.Add(new Candidate("Lib Dem", "Karren", "Lattimer", 110));

            //return the constituency
            return constituency;
        }
    }
}
