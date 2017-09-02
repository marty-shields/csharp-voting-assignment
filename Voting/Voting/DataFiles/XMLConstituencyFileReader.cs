using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace Voting
{
    public class XMLConstituencyFileReader : IConstituencyFileReader
    {
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            //create list of candidates
            List<Candidate> candidates = new List<Candidate>();

            // Open the file to read from on the local file system.
            // If this file is missing then return immediately from this method.

            if (!File.Exists(configRecord.Filename))
            {
                // Cannot open the file as it does not exist for whatever reason, so return immediately.
                return null;
            }

            // Open file and load into memory as XML
            XDocument xmlDoc = XDocument.Load(configRecord.Filename);

            // Create constituency and get the name in order to create the constituency object
            var constituencyName = (from constit in xmlDoc.Descendants("Constituency")
                                    select constit.Attribute("name").Value).First();

            //get the candidate details and put them into candidate object then to candidate list
            IEnumerable<XElement> candidateDeatails = (from cand in xmlDoc.Descendants("Candidate")
                                                       select cand);

            //add each candidate into a candidate list which will be added
            foreach(XElement cand in candidateDeatails)
            {
                Candidate candidate = new Candidate(cand.Attribute("party").Value.ToString(), cand.Element("Firstname").Value.ToString(),
                                                    cand.Element("Lastname").Value.ToString(), Convert.ToInt32(cand.Element("Votes").Value));
                candidates.Add(candidate);
            }

            Constituency constituency = new Constituency(constituencyName);
            constituency.candidates = candidates;

            // Create and return a constituency based on report name and measures
            return constituency;
        }
    }
}
