using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Voting;
using VotingTests.Dependencies;
using TestedClass = Voting.Consumer;

namespace VotingTests.Fixtures
{
    [TestClass]
    public class TextFixture_Consumer
    {
        //set up objects and variables needed for the test class
        TestedClass testedClass = null;
        ProgressManager progressManager = null;
        ConstituencyList constituencyList = null;
        IPCQueue pcQueue = null;
        string failMsg;

       //set up test cleaner so we null everything when finishing test so no issues to do more tests
       [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            progressManager = null;
            constituencyList = null;
            pcQueue = null;
        }

        //first test in order to see if one thread is created and is working as expected
        [TestMethod]
        public void Test_One_Thread_Created()
        {
            //Arrange
            //Instanicate required objects
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);
            //expected result
            var expectedThreadCount = 1;

            //Act
            //Wait a few seconds to allow consumer thread to wake up
            Thread.Sleep(5000);

            //by the time the sleep has finished the consumer should of started a single thread and incremented count by 1
            var actualThreadCount = TestedClass.RunningThreads;

            //signer consumer thread to finish
            testedClass.Finished = true;

            //allow short period to allow consumer to finish
            Thread.Sleep(1000);

            //Assert both results are correct
            failMsg = "Test failed because the amount of threads that were used was not what it should be";
            Assert.AreEqual(expectedThreadCount, actualThreadCount, failMsg);
        }

        //test to see if the amount of constituencys created is the same as the amount in progress manager
        [TestMethod]
        public void Test_Run_Method_Constituencys_Created_Equals_Progress_Mananger_Accesses()
        {
            // Arrange
            // Instantiate the required objects
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few milliseconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have created as many constituencys as progress manager accesses, we do not know how many though
            Thread.Sleep(6000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // Expected ProgressManager accesses can be determined by the abs value of the ItemsRemaining property, one of these
            // for each time a constituency is added to the constituencys list
            Assert.AreEqual(Math.Abs(progressManager.ItemsRemaining), constituencyList.constituencys.Count);
        }

        //test to make sure that when the consumer runs null it picks up null in dequeue then no items are 0 
        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_ProgressManager_Accesses()
        {
            // Arrange
            // Instantiate the required objects
            pcQueue = new PCQueueNullDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few seconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have dequeued a number of nulls each of which should be ignored, we do not know how many though and it does not
            // matter (if it works for one it works for all)
            Thread.Sleep(6000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // There should be no accesses of the ProgressManager
            Assert.AreEqual(0, Math.Abs(progressManager.ItemsRemaining));
        }

        //test that when there is nul in the que that there will be no constituencys in the list
        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_Constituencys()
        {
            // Arrange
            // Instantiate the required objects
            pcQueue = new PCQueueNullDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few seconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have dequeued a number of nulls each of which should be ignored, we do not know how many though and it does not
            // matter (if it works for one it works for all)
            Thread.Sleep(5000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // There should be no coinstituencys added to the constituency list
            Assert.AreEqual(0, constituencyList.constituencys.Count);
        }
    }
}
