using System;
using System.Threading;

namespace Voting
{
    public class Consumer
    {
        private static int runningThreads = 0; // Class wide count of consumer threads that are running
        private static object locker = new object(); // Used for MUTEX control of static properties
        private const int duration = 2000; // Simulates the time taken to consume a work item (in milliseconds)

        private string id; // Identifier for this consumer
        public Thread T { get; private set; } // Thread upon which this instance of a consumer runs
        private bool finished; // Flag to control if this consumer has finished or if it should
                               // continue to consume
        private IPCQueue pcQueue; // Shared PCQueue that this consumer is consuming work items from

        private ConstituencyList constituencyList; // List of constiuencies which will be added to

        private ProgressManager progManager;

        public static int RunningThreads // Property getter/setter methods
        {
            get
            {
                return runningThreads;
            }

            private set
            {
                lock (locker)
                {
                    // MUTEX control for potential multiple thread access to this property
                    runningThreads = value;
                }
            }
        }

        public bool Finished // Property getter/setter methods
        {
            get
            {
                return finished;
            }

            set
            {
                lock (this)
                {
                    // MUTEX control for potential multiple thread access to the finished flag
                    finished = value;
                }
            }
        }

        public Consumer(string id, IPCQueue pcQueue, ConstituencyList constituencyList, ProgressManager progManager)
        {
            this.id = id;
            finished = false; // Initially not finished
            this.pcQueue = pcQueue;
            this.constituencyList = constituencyList;
            this.progManager = progManager;
            (T = new Thread(Run)).Start(); // Create a new thread for this consumer and get it started
            RunningThreads++; // Increment the number of running consumer threads;
        }

        // Thread code for the consumer
        public void Run()
        {
            // While not finished, dequeue a work item from the PCQueue and consume this work item by invoking
            // its ReadData() method and then outputting to the console a message to show this has happened
            while (!Finished)
            {
                // Dequeue a work item
                var item = pcQueue.dequeueItem();

                if (!ReferenceEquals(null, item))
                {
                    // Invoke the work item's ReadData() method, which returns a constituency
                    Constituency constituency = item.ReadData();

                    // Ensure null returns are ignored (will happen if data not in correct format or can't open file)
                    if (!ReferenceEquals(null, constituency))
                    {
                        // Add this constituency to the coinstituency list (lock it while modifying) 
                        lock (constituencyList)
                        {
                            constituencyList.constituencys.Add(constituency);
                        }
                        // Output to the console
                        Console.WriteLine("Consumer:{0} has consumed Work Item:{1}", id, item.configRecord.ToString());
                    }
                    else
                    {
                        // Output to the console
                        Console.WriteLine("Consumer:{0} has rejected Work Item:{1}", id, item.configRecord.ToString());
                    }

                    // Simulate consumer activity running for duration milliseconds
                    Thread.Sleep(duration);

                    progManager.ItemsRemaining--;
                }
            }

            // Decrement the number of running consumer threads
            RunningThreads--;

            // Output that this consumer has finished
            Console.WriteLine("Consumer:{0} has finished", id);
        }
    }
}
