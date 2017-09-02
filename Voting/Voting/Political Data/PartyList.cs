using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class PartyList
    {
        public List<Party> partys { get; set; }

        public PartyList()
        {
            partys = new List<Party>();
        }

        //this sets up each party putting the correct candidates and details into them
        public void setUpPartyList(ConstituencyList constituencyList)
        {
            //loop to take each contituency
            foreach (Constituency constituency in constituencyList.constituencys)
            {
                foreach (Candidate candidate in constituency.candidates)//loop to take candidates out of constituency to get the party name
                {
                    if (partys.Count > 0) // see if the list is empty if so go and add item straight in
                    {//if not then LINQ query to search through the whole list for a value
                        IEnumerable<Party> partyAlreadyAddedQuery = from p in partys
                                                                    where p.partyName == candidate.partyName
                                                                    select p;
                        if (!partyAlreadyAddedQuery.Any()) // if theres nothting in the query
                        {
                            partys.Add(new Party(candidate.partyName, candidate));//add the party object to the list as long as there is not one there
                        }
                        else // if theres is something in the query search through the parties and add the candidate
                        {
                            foreach (Party p in partys)
                            {
                                // if the party name of the party is the same as the party name of the candidate add the candidate to the list
                                if (p.partyName == candidate.partyName)
                                {
                                    p.CandidateList.Add(candidate);
                                }
                            }
                        }
                    }
                    else
                    {
                        partys.Add(new Party(candidate.partyName, candidate)); //this allows to add the first party into the party list
                    }
                }
            }
        }
    }
}
