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
        public static Form1 form1;

        [STAThread]
        static void Main(string[] args)
        {
            state = new State();
            state.LoadRom(@"c:\invaders");
            Thread thread1 = new Thread(new ThreadStart(test));
            thread1.Start();

            form1 = new Form1();

            Application.Run(form1);
        }

        static void test()
        {
            state.Run();

        }
    }
}