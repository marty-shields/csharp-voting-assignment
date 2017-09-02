using System;
using System.Threading;

namespace Voting
{
    public class Producer
    {
        private static int runningThreads = 0; // Class wide count of producer threads that are running
        private static object locker = new object(); // Used for MUTEX control of static properties
        private const int duration = 1500; // Simulates the time taken to produce a work item (in milliseconds)

        private string id; // Identifier for this producer
        public Thread T { get; private set; } // Thread upon which this instance of a producer runs
        private bool finished; // Flag to control if this producer has finished or if it should
                               // continue to produce
        private IPCQueue pcQueue; // Shared PCQueue that this producer is producing work items for

        private ConfigData configFile; // Configuration data (details of datasets to be processed)
        private IConstituencyFileReader IOhandler; // File handler for reading data

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
                    // MUTEX control for potential multiple thread access to this property
                    finished = value;
                }
            }
        }

        public Producer(string id, IPCQueue pcQueue, ConfigData configFile, IConstituencyFileReader IOhandler)
        {
            this.id = id;
            finished = false; // Initially not finished
            this.pcQueue = pcQueue;
            //counter = 0; // Initial value for the work item counter]
            this.configFile = configFile;
            this.IOhandler = IOhandler;
            (T = new Thread(Run)).Start(); // Create a new thread for this producer and get it started
            RunningThreads++; // Increment the number of running producer threads;
        }

        // Thread code for the producer
        public void Run()
        {
            ConfigRecord configRecord = null;

            // While not finished, generate a new work item and enqueue it on the PCQueue, output that this producer has
            // produced a new item (and what it is called)
            while (!Finished)
            {
                // Lock configuration file and obtain next filename to process
                // If there are no filenames left then set filename to null so that nothing is produced
                lock (configFile)
                {
                    if (configFile.NextRecord < configFile.configRecords.Count)
                    {
                        configRecord = configFile.configRecords[configFile.NextRecord++];
                    }
                    else
                    {
                        configRecord = null;
                    }
                }

                // only queue item if there is a config record to read
                if (configRecord != null)
                {
                    // Enqueue a new work item, increment the counter as this work is produced
                    pcQueue.enqueueItem(new Work(configRecord, IOhandler));

                    // Output a message to state that this producer has produced a work item
                    Console.WriteLine("Producer:{0} has created and enqueued Work Item:{1}", id, configRecord.ToString());
                }

                // Simulate producer activity running for duration milliseconds
                Thread.Sleep(duration);
            }

            // Decrement the number of running producer threads
            RunningThreads--;

            // Output that this producer has finished
            Console.WriteLine("Producer:{0} has finished", id);
        }
    }
}
