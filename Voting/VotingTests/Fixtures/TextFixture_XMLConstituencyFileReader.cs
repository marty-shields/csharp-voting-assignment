using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voting;
using VotingTests.Helpers;
using TestedClass = Voting.XMLConstituencyFileReader;

namespace VotingTests.Fixtures
{
    [TestClass]
    public class TextFixture_XMLConstituencyFileReader
    {
        //null tested class for start
        TestedClass testedClass = null;

        //null tested class so that it is ready for next tests
        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Cyclist01_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_And_Valid("constituency-1.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Cyclist03_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_And_Valid("constituency-3.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Cyclist05_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_And_Valid("constituency-5.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency05());
        }

        //test to see if the file does not exist
        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Does_Not_Exist()
        {
            // Arrange
            // A file with this name does not exist
            var fileName = "iAmFake";

            //instanciate the XMLConstituencyFileReaderObject
            testedClass = new TestedClass();

            // Act
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            Assert.IsNull(actualConstituency);
        }

        //test to make sure the correct exception is done when the file is not an XML file and is corrupt
        [TestMethod]
        [ExpectedException(typeof(System.Xml.XmlException))]
        public void Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Invalid()
        {
            // Arrange
            // A file with this name should exists and contains a error in the document
            var fileName = "constituency-1-Fail.xml";

            //instanciate the XMLConstituencyFileReaderObject
            testedClass = new TestedClass();

            // Act call the method to load up the file and the system should see that is invalid and throw the exception
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            // Should not reach here due to exception being raised, if reached then force the test to fail
            Assert.Fail("ERROR: should have thrown System.Xml.XmlException before reaching here!");
        }

        //helper method so that it can be run into other tests in this text fixture to check the files
        private void Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_And_Valid(string fileName, Constituency expectedConstituency)
        {
            //instanciate the XMLConstituencyFileReaderObject
            testedClass = new TestedClass();

            // Act call the method to load up the file
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            // Check each property of the expected and actual constituency instances to make sure they contain the same data
            Assert.AreEqual(expectedConstituency.constituencyName, actualConstituency.constituencyName);

            //check to make sure the same candidates are in as well by checking length
            Assert.AreEqual(expectedConstituency.candidates.Count, actualConstituency.candidates.Count);

            //now check each candidate to make sure the data is the same across all of them
            for (var i = 0; i < expectedConstituency.candidates.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.candidates[i].firstName, actualConstituency.candidates[i].firstName);
                Assert.AreEqual(expectedConstituency.candidates[i].lastName, actualConstituency.candidates[i].lastName);
                Assert.AreEqual(expectedConstituency.candidates[i].partyName, actualConstituency.candidates[i].partyName);
                Assert.AreEqual(expectedConstituency.candidates[i].votes, actualConstituency.candidates[i].votes);
            }

        }
    }
}
