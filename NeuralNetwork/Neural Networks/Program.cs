using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Networks
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
            
            NeuralNetworkGUI gui = new NeuralNetworkGUI();
            Controller controller = new Controller(gui, new Model());
            
            Application.Run(gui);
        }
    }
}
