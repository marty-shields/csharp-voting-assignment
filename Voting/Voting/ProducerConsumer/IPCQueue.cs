using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public interface IPCQueue
    {
        void enqueueItem(Work item);
        Work dequeueItem();
    }
}
