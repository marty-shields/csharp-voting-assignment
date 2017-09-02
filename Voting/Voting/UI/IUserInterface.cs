using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    interface IUserInterface
    {
        void SetupConfigData();
        void RunProducerConsumer();
        void DisplayConstituencys();
        void SetupPartyInformation();
    }
}
