using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting;
using VotingTests.Helpers;

namespace VotingTests.Dependencies
{
    class ConstituencyFileReaderReturnKnownConstituency03 : IConstituencyFileReader
    {
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            //use a helper class to get a known constituency 03 instance
            return Helper_KnownConstituencyDataRepository.GetKnownConstituency03();
        }
    }
}
