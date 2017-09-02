using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;

namespace VotingTests.Dependencies
{
    class PCQueueKnownDequeued : IPCQueue
    {
        public void enqueueItem(Work item)
        {
            // Can be left as an empty stub since it is not called 
        }

        public Work dequeueItem()
        {
            // Dequeue a dummy Work instance
            var work = new Work(new ConfigRecord("Constituency-03.xml"), new ConstituencyFileReaderReturnKnownConstituency03());
            return work;
        }
    }
}
