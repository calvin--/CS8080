using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS8080
{
    public class Program
    {
        static void Main(string[] args)
        {
            State state = new State();
            state.LoadRom(@"c:\invaders");
            state.Run();
            state.registers.DumpRegisters();
            Console.ReadLine();
        }
    }
}