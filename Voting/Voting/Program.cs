using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //run console for testing
            // Create IO Handler (in this case a local file reader
            var IOhandler = new XMLConstituencyFileReader();
            Application.Run(new WinFormBasedUI(IOhandler));
        }
    }
}
