using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Voting;
using VotingTests.Helpers;
using VotingTests.Dependencies;
using TestedClass = Voting.Work;

namespace VotingTests.Fixtures
{
    [TestClass]
    public class TextFixture_Work
    {
        //this test makes sure that all of the data being read by work is correct in every place to do with constituency and candidates
        [TestMethod]
        public void Test_ReadData_Method_Correct_Constituency_Returned()
        {
            // Arrange
            // Use the CyclistFileReaderReturnKnownCyclist03 implementation of ICyclistFileReader which simply returns a
            // known Cyclist instance from its ReadCyclistDataFromFile() method, note that no ConfigRecord if actually
            // needed so this can be passed as a null
            var ioHandler = new ConstituencyFileReaderReturnKnownConstituency03();

            // Instantiate a Work object
            var testedClass = new TestedClass(null, ioHandler);

            // Use helper class to get a known cyclist 03 instance
            var expectedConstituency = Helper_KnownConstituencyDataRepository.GetKnownConstituency03();

            // Act
            // Call the ReadData() method of the Work instance and the data held in the constituency returned from this should
            // be identical to the data held in the expected constituency instance
            var actualConstituency = testedClass.ReadData();

            // Assert
            // Check each property of the expected and actual constituency instances to make sure they contain the same data
            // First check constituency properties
            Assert.AreEqual(expectedConstituency.constituencyName, actualConstituency.constituencyName);

            //check to make sure the same candidates are in as well by checking length
            Assert.AreEqual(expectedConstituency.candidates.Count, actualConstituency.candidates.Count);

            //now check each candidate to make sure the data is the same across all of them
            for(var i = 0; i < expectedConstituency.candidates.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.candidates[i].firstName, actualConstituency.candidates[i].firstName);
                Assert.AreEqual(expectedConstituency.candidates[i].lastName, actualConstituency.candidates[i].lastName);
                Assert.AreEqual(expectedConstituency.candidates[i].partyName, actualConstituency.candidates[i].partyName);
                Assert.AreEqual(expectedConstituency.candidates[i].votes, actualConstituency.candidates[i].votes);
            }
        }
    }
}
