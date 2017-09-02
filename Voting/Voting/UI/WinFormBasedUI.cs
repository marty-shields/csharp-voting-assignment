using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Voting
{
    public partial class WinFormBasedUI : Form , IUserInterface
    {
        #region variables to use in class

        private IConstituencyFileReader IOhandler;
        private ConfigData configData;
        private ConstituencyList constituencyList;
        private PartyList partyList;
        private ICalculations calculations = new ConstiuencyCalculations(); // create an object of the calcuations class
        private Dictionary<string,string> fileList = new Dictionary<string, string>(); //dictionary for the file list for easy lookup

        #endregion

        public WinFormBasedUI(IConstituencyFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        public void resetOutputs() //method in order to clear outputs
        {
            cboConstituencys.Items.Clear();
            lsConstituency.Items.Clear();
            lsPartyDetails.Items.Clear();
            lblListTitle.Text = "";
            lblListTitle.Refresh();
        }

        #region data setup from XML into lists etc

        //setting up the data getting the user to choose the files they wish to use
        public void SetupConfigData()
        {
            // Make sure configData is a new empty object
            configData = new ConfigData();
               
            // Generate configuration data (filename and required for each constituency)
            foreach (string file in fileList.Keys)
            {
                configData.configRecords.Add(new ConfigRecord(file));
            }
        }

        public void RunProducerConsumer()
        {
            //Create constituency list as null to hold individual constituency objects read from datasets
            constituencyList = new ConstituencyList();

            // Create progress manager with number of files to process
            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            // Output message to indicate that the program has started
            Console.WriteLine("=================================================");
            Console.WriteLine("Creating and starting all producers and consumers");
            Console.WriteLine("=================================================");
            Console.WriteLine();

            // Create a PCQueue instance, give it a capacity of 4
            var pcQueue = new PCQueue(4);

            // Create 2 Producer instances and 2 Consumer instances, these will begin executing on
            // their respective threads as soon as they are instantiated
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler),
                                     new Producer("P2", pcQueue, configData, IOhandler) };
            Consumer[] consumers = { new Consumer("C1", pcQueue, constituencyList, progManager),
                                     new Consumer("C2", pcQueue, constituencyList, progManager) };

            // Keep producing and consuming until all work items are completed
            while (progManager.ItemsRemaining > 0) ;

            // Output message to indicate that the program is shutting down
            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("Shutting down all producers and consumers");
            Console.WriteLine("=========================================");
            Console.WriteLine();
            // Deactivate the PCQueue so it does not prevent waiting producer and/or consumer threads
            // from completing
            pcQueue.Active = false;

            // Iterate through producers and signal them to finish
            foreach (var p in producers)
            {
                p.Finished = true;
            }

            // Iterate through consumers and signal them to finish
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            // We need to ensure that no thread waiting on Monitor.Wait() is stranded with
            // no Monitor.Pulse() now possible since all producer and consumer threads have
            // been signalled to stop, in the worse case all such threads could be stranded
            // so pulse that many times to ensure enough pulses are made available (or the
            // program can halt erroneously), wasted pulse are simply ignored 
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    // Pulse the PCQueue to signal any waiting threads
                    Monitor.Pulse(pcQueue);

                    // Give a short break to the main thread so the pulses have time to be
                    // detected by any potentially waiting producer and/or consumer threads
                    Thread.Sleep(1000);
                }
            }

            // Once all producer and consumer threads have finally finished we can gracefully
            // shutdown the main thread, this is achieved by spinning on a while() loop until
            // there are no running threads, in this case we do not mind the main thread
            // spinning as we are about to shutdown the program
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ; // Wait by spinning

            Console.WriteLine();
            Console.WriteLine("============================================================");
            Console.WriteLine("All producers and consumers shut down");
            Console.WriteLine("============================================================");
        }

        //function in order to take the constituency list and re order into a party class and party list in order to use the data in another way
        public void SetupPartyInformation()
        {
            //instanciate party list as null to stop duplications
            partyList = new PartyList();

            //set up each party with the correct details in
            partyList.setUpPartyList(constituencyList);

            //run foreach loop to calculate total votes for each party
            foreach (Party party in partyList.partys)
            {
                party.totalVotes = calculations.CalculatePartyTotalVotes(party);
            }

        }

        #endregion

        #region buttons for main page tab

        private void btnProcessData_Click(object sender, EventArgs e)
        {
            if (fileList.Count > 0)
            {
                //clear out all outputs
                resetOutputs();

                txtProgress.Text = " ";//inform user of update to status
                txtProgress.Refresh();

                txtProgress.Text = "Obtaining political data. Please wait";//inform user of update to status
                txtProgress.Refresh();

                //set up the files to be read into the file reader class
                SetupConfigData();

                RunProducerConsumer(); //run producer and consumer to load up the data of constituencys

                txtProgress.Text = "Political data obtained. Now ordering data";//inform user of update to status
                txtProgress.Refresh();

                //show up the constituencies on the correct tabs
                DisplayConstituencys();

                //set up each party for the classes in order to be able to process
                SetupPartyInformation();

                txtProgress.Text = "Political data fully loaded and ordered and is ready to use";//inform user of update to status

                //enable buttons and other UI
                cboConstituencys.Enabled = true;
                btnPartyAlpha.Enabled = true;
                btnPartyVotes.Enabled = true;
                btnShowElected.Enabled = true;
                btnShowWinner.Enabled = true;
                btnPartyDetails.Enabled = false;

                MessageBox.Show("Political data is fully loaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No files are loaded please load files first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //function in order to add a file to process
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            //try catch to make sure we get a file, the correct file and to catch any other errors
            try {
                //set a file dialogue
                OpenFileDialog openFile = new OpenFileDialog();
                //setting properties for file diaglogue
                openFile.Title = "Please choose a XML file"; // this is the titel of the dialogue
                openFile.Filter = "XML Files|*.xml"; //this allows the user to only select XML files
                openFile.CheckFileExists = true; //makes sure the file exists if not then warning comes up
                openFile.CheckPathExists = true; //makes sure the path exists if not then warning comes up
                openFile.Multiselect = true; //able to select more than one file

  
                DialogResult dr = openFile.ShowDialog();
                //if the user chooses a file and clicks ok do something
                if (dr == DialogResult.OK)
                {
                    //running through each file selected
                    foreach (string file in openFile.FileNames)
                    {
                        //add it to personal dictionary storing the file name as the key and the full path as the value
                        string fileName = Path.GetFileName(file);
                        string fullPath = Path.GetFullPath(file);
                        Console.WriteLine(fileName);
                        Console.WriteLine(fullPath);//debugging

                        //load the file into xDoc and check for a constituency node
                        XDocument xDoc = XDocument.Load(fullPath);

                        //see ifd there is a constituency node and theres something in it
                        var testNode = from constit in xDoc.Descendants("Constituency")
                                       select constit;

                        //check for nodes are correct
                        if (testNode.Count() != 0)
                        {

                            //make sure the filename and full path are not already there
                            if (!fileList.ContainsKey(fullPath))
                            {
                                //add the file to the file list
                                fileList.Add(fullPath, fileName);
                            }
                            else
                            {
                                MessageBox.Show("File/s with that path is already loaded please load a different file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("File/s loaded do not have the correct nodes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                UpdateFileList();

                btnProcessData.Enabled = true;
            }
            catch(XmlException)
            {
                MessageBox.Show("XML file is corrupt or XML file is not selected please try another file" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IOException IOE)
            {
                MessageBox.Show(IOE.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //button so we can remove the selected file from the list
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            //make sure there is a file selected from the list
            if(lsFileList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a file to be removed from the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //LINQ statement to get the key from the path as we are showing the value
                var key = (from filePath in fileList
                           where filePath.Value.Contains(lsFileList.SelectedItem.ToString())
                           select filePath.Key).First();

                //remove the file from the file list dictionary
                fileList.Remove(key);

                //update the file list list box
                UpdateFileList();
            }
        }

        //method to update the list box which shows which files will be loaded
        public void UpdateFileList()
        {
            //clear the list box of items
            lsFileList.Items.Clear();

            //add each from the dictionary into the list box
            foreach (string fileName in fileList.Values)
            {
                lsFileList.Items.Add(fileName);
            }
        }
        #endregion

        #region buttons for constituency tab

        //function in order to display the constituencys in the combo box on another tab
        public void DisplayConstituencys()
        {
            // Having finished generating data we can now display constituency data
            Console.WriteLine();
            Console.WriteLine("============================================================");
            foreach (var constituency in constituencyList.constituencys)//add each constiuency to the list
            {
                cboConstituencys.Items.Add(constituency); //adding constituency to the list
                Console.WriteLine("Constituency read from XML data: {0}", constituency.ToString());

            }
            Console.WriteLine("============================================================");
        }

        //button in order to show teh details for the canddadite chosen
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            //make sure something is chosen in the list box
            if (lsConstituency.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a candidate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lsConstituency.SelectedItem is Candidate)//if statement to make sure what is goign through actually is a candidate
                {
                    //create a candaidate object to show the candidate details (easier for viewing purposes)
                    Candidate selectedCandidate = (Candidate)lsConstituency.SelectedItem;
                    string message = String.Format("\tCandidate\n\n\tName:  {0} {1}\t\n\n\tParty:  {2} \n\n\tNumber of Votes:  {3}", selectedCandidate.firstName, selectedCandidate.lastName,
                                                                                                    selectedCandidate.partyName, selectedCandidate.votes.ToString());
                    MessageBox.Show(message, "Candidate Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a candidate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cboConstituencys_SelectedIndexChanged(object sender, EventArgs e) // updating the list box with the selected constituency
        {
            if (cboConstituencys.SelectedIndex != -1)
            {
                //allow the show candidate details button be clicked
                btnShowDetails.Enabled = true;

                lsConstituency.Items.Clear(); // clear the list box first
                Constituency selectedConstituency = (Constituency)cboConstituencys.SelectedItem; //make an object of the selected item
                lblListTitle.Text = "Constituency: " + selectedConstituency.ToString(); //change the textbox of the selected constituency as the name
                lblListTitle.Refresh();

                foreach (Candidate candidate in selectedConstituency.candidates)
                {
                    lsConstituency.Items.Add(candidate);
                }
            }
        }
        public void btnShowElected_Click(object sender, EventArgs e) //button in order to select the elected candidates for each constituency
        {

            //set up outputs to view
            btnShowDetails.Enabled = true;
            cboConstituencys.SelectedIndex = -1;
            lsConstituency.Items.Clear();
            lblListTitle.Text = "Elected Candidates For Each Constituency";
            //go through each constituency and add the constituency anmd the elected candidate
            foreach (Constituency constituency in constituencyList.constituencys)
            {
                lsConstituency.Items.Add(constituency);
                lsConstituency.Items.Add(calculations.CalculateElectedCandidates(constituency));
                lsConstituency.Items.Add("---------------------------------------");
            }
        }

        #endregion

        #region buttons for party tab

        //show the party details in order of althabetically
        private void btnPartyAlpha_Click(object sender, EventArgs e)
        {
            lsPartyDetails.Items.Clear(); //clear the list first
            lsPartyDetails.Items.Add(String.Format("{0,-23}{1,1}", "Party", "Total Votes"));

            // do a foreach loop based on a LINQ statement on a seperate functionm
            foreach (Party party in calculations.SortPartyAlphabetically(partyList))
            {
                //add the party details then the total votes for the party then a break line to split partys up
                lsPartyDetails.Items.Add(party);
            }

            btnPartyDetails.Enabled = true;
        }

        //calculate the winner and show in a message box
        private void btnShowWinner_Click(object sender, EventArgs e)
        {
            Party winningParty = (Party)calculations.CalculatePartyWinner(partyList);
            //creating a custom string so we can add to a message box containing the party with the most votes
            string partyWinner = String.Format("The Winning Party Is... \n\n{0}!\n\nTotal Votes:  {1}", winningParty.partyName, winningParty.totalVotes);

            MessageBox.Show(partyWinner, "Party Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //do a linq statement on the party votes going from most to least and show in a list box
        private void btnPartyVotes_Click(object sender, EventArgs e)
        {
            lsPartyDetails.Items.Clear(); //clear the list first
            lsPartyDetails.Items.Add(String.Format("{0,-23}{1,1}", "Party", "Total Votes"));
            // do a foreach loop based on a LINQ statement on a seperate functionm
            foreach (Party party in calculations.SortPartyByVotes(partyList))
            {
                //add the party details then the total votes for the party then a break line to split partys up
                lsPartyDetails.Items.Add(party);
            }
            btnPartyDetails.Enabled = true;
        }

        //do a linq query to get the candidate for a party alphabetically and show in a message box the details for the party
        private void btnPartyDetails_Click(object sender, EventArgs e)
        {
            //make sure something in the list is selected first
            if (lsPartyDetails.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //message bozx when nothing is selected
            }
            else
            {
                if (lsPartyDetails.SelectedItem is Party)//if statement to make sure what is goign through actually is a candidate
                {
                    //get the party object from the selected item
                    Party selectedParty = (Party)lsPartyDetails.SelectedItem;

                    //start a string up for the message box showing the party and votes
                    string message = String.Format("\tParty Name:  {0}\n\n\tTotal Votes:  {1}\n\n\tCandidates:\t\t\n",
                        selectedParty.partyName, selectedParty.totalVotes.ToString());

                    //run through each candidate in the linq query and add to custom string
                    foreach(Candidate candidate in calculations.SortCandidatesAlphabetically(selectedParty))
                    {
                        message += "\t" + candidate.firstName + " " + candidate.lastName + "\n";
                    }

                    //show message 
                    MessageBox.Show(message, "Party Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

    }
}
