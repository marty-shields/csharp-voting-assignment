using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voting;
using VotingTests.Helpers;
using System.Linq;
using TestedClass = Voting.PartyList;

namespace VotingTests.Fixtures
{
    [TestClass]
    public class TextFixture_PartyList
    {
        ConstituencyList constituencyList;
        TestedClass testedClass = new TestedClass();
        PartyList partyList;

        //set up test first populating the expected result for the party list it self
        [TestInitialize]
        public void TestInitialize()
        {
            //set up a constituency list of fizxed data to pass through to the party class
            constituencyList = new ConstituencyList();
            constituencyList.constituencys.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
            constituencyList.constituencys.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
            constituencyList.constituencys.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency05());

            //set up party list
            partyList = new PartyList();

            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyConservative(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyScottishNationalParty(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyLabour(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyLibDem(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyGreen(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartySinnFein(constituencyList));
            partyList.partys.Add(Helper_KnownPartyDataRepositry.GetKnownPartyPlaidCymru(constituencyList));
        }
        
        //test to see if the party data is the same across both the party lists
        [TestMethod]
        public void Test_Party_List_Data_Is_Gathering_Correctly()
        {
            
            //Arrange get the expected result
            var expectedResult = partyList;

            //Act
            //get the actual result of what the parties actually have
            testedClass.setUpPartyList(constituencyList);

            //Assert
            //make sure the count for each party list is the same first
            Assert.AreEqual(expectedResult.partys.Count, testedClass.partys.Count);

            //make sure each of the data in each party is the same in the lists
            for(int i = 0; i < expectedResult.partys.Count; i++)
            {
                Assert.AreEqual(expectedResult.partys[i].partyName, testedClass.partys[i].partyName);
                Assert.AreEqual(expectedResult.partys[i].totalVotes, testedClass.partys[i].totalVotes);
            }

            //make sure coutns for candidates in each party is the same
            for (int i = 0; i < expectedResult.partys.Count; i++)
            {
                Assert.AreEqual(expectedResult.partys[i].CandidateList.Count, testedClass.partys[i].CandidateList.Count);
            }

            //make sure each candidate detail is correct
            for (int i = 0; i < expectedResult.partys.Count; i++)
            {
                for (int a = 0; a < expectedResult.partys[i].CandidateList.Count; a++)
                {
                    Assert.AreEqual(expectedResult.partys[i].CandidateList[a].firstName, testedClass.partys[i].CandidateList[a].firstName);
                    Assert.AreEqual(expectedResult.partys[i].CandidateList[a].lastName, testedClass.partys[i].CandidateList[a].lastName);
                    Assert.AreEqual(expectedResult.partys[i].CandidateList[a].partyName, testedClass.partys[i].CandidateList[a].partyName);
                    Assert.AreEqual(expectedResult.partys[i].CandidateList[a].votes, testedClass.partys[i].CandidateList[a].votes);
                }
            }
        }
    }
}
