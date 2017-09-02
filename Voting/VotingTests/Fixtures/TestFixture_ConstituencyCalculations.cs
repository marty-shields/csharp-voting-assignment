using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voting;
using TestedClass = Voting.ConstiuencyCalculations;
using VotingTests.Helpers;
using VotingTests.Dependencies;

namespace VotingTests.Fixtures
{
    [TestClass]
    public class TestFixture_ConstituencyCalculations
    {
        //setup variables first
        TestedClass testedClass = new TestedClass();
        PartyList partyList;
        ConstituencyList constituencyList;
        ConstituencyCalculationsReturningConservativeTotalVotes conservativeTotalVotes;

        [TestInitialize]
        public void TestInitialise()
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

        //test to make sure the calculation to get the party total votes is done correctly
        [TestMethod]
        public void Test_CalculatePartyTotalVotes_Adding_Up_Correctly_Conservative_Party()
        {
            //Arrange
            //set up the expected result
            //setup dependancy class
            conservativeTotalVotes = new ConstituencyCalculationsReturningConservativeTotalVotes();

            //get the stub result from the dependancy class (the party going through is irrelivant as it is returning a fixed value)
            var expectedResult = conservativeTotalVotes.CalculatePartyTotalVotes(partyList.partys[0]);

            //Act
            //run the conservative party through the total votes system to make sure it works
            var actualResult = testedClass.CalculatePartyTotalVotes(partyList.partys[0]);

            //assert
            //make sure both results are the same
            string failMessage = "The total votes for the conservative party do not add up correctly to the actual total";
            Assert.AreEqual(expectedResult, actualResult, failMessage);
        }

        //test to make sure the calculation to get the party total votes is done correctly
        [TestMethod]
        public void Test_CalculatePartyTotalVotes_Adding_Up_Correctly_Green_Party()
        {
            //Arrange
            //set up the expected result
            var expectedResult = 240;

            //Act
            //run the green party through the total votes system to make sure it works
            var actualResult = testedClass.CalculatePartyTotalVotes(partyList.partys[4]);

            //assert
            //make sure both results are the same
            string failMessage = "The total votes for the green party do not add up correctly to the actual total";
            Assert.AreEqual(expectedResult, actualResult, failMessage);
        }

        //test to make sure the correct person is selected as the elected candidate for each constituency
        [TestMethod]
        public void Test_CalculateElectedCandidates_Choosing_Correct_Candidate()
        {
            //Arrange
            //set up a candidate who is the winner for each constituency
            var expectedResultConstituency1 = constituencyList.constituencys[0].candidates[0];
            var expectedResultConstituency2 = constituencyList.constituencys[1].candidates[0];
            var expectedResultConstituency3 = constituencyList.constituencys[2].candidates[0];

            //Act 
            //get actual results from the calculation
            var actualResultConstituency1 = testedClass.CalculateElectedCandidates(constituencyList.constituencys[0]);
            var actualResultConstituency2 = testedClass.CalculateElectedCandidates(constituencyList.constituencys[1]);
            var actualResultConstituency3 = testedClass.CalculateElectedCandidates(constituencyList.constituencys[2]);

            //Assert
            //make sure both values are equal
            string failMessage = "the correct candidate is not selected for this constituency(i.e teh one witht he highest votes)";
            Assert.AreEqual(expectedResultConstituency1, actualResultConstituency1, failMessage);
            Assert.AreEqual(expectedResultConstituency2, actualResultConstituency2, failMessage);
            Assert.AreEqual(expectedResultConstituency3, actualResultConstituency3, failMessage);
        }

        //test to make sure the system chooses the correct party winner (in this example it is the conservative)
        [TestMethod]
        public void Test_CalculatePartyWinner_Correct_Party_Chosen()
        {
            //arrange 
            //since the total votes under the conservative party has the highest votes then it will be that we will test against
            var expectedResult = partyList.partys[0];

            //Act
            //run the function to test to calculate the party winner 
            var actualResult = testedClass.CalculatePartyWinner(partyList);

            //Assert
            //make sure both are correct
            string failMessage = "The party calculated is not the same as the party which has the highest total votes";
            Assert.AreEqual(expectedResult, actualResult, failMessage);
        }

    }
}
