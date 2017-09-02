using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;

namespace VotingTests.Dependencies
{
    class PCQueueNullDequeued : IPCQueue
    {
        public void enqueueItem(Work item)
        {
            // Can be left as an empty stub since it is not called 
        }

        public Work dequeueItem()
        {
            // A null is dequeued
            return null;
        }
    }
}
