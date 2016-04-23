using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS8080
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            this.KeyPreview = true;
            InitializeComponent();
            /*
            State state = new State();
            state.LoadRom(@"c:\invaders");
            state.Run();
            state.registers.DumpRegisters();
            Console.ReadLine();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Program.state.ProcessInput(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Program.state.ProcessInput(Keys.J);
        }
    }
}
