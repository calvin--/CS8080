using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace CS8080
{
    public class Program
    {
        public static State state;
        public static MainWindow mainWindow;

        [STAThread]
        static void Main(string[] args)
        {
            state = new State();
            state.LoadRom(@"c:\invaders");
            
            Thread emulatorThread = new Thread(new ThreadStart(state.Run));
            emulatorThread.Start();

            mainWindow = new MainWindow();

            Application.Run(mainWindow);
        }
    }
}