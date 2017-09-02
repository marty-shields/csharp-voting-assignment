using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public interface IConstituencyFileReader
    {
        Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord);
    }
}
