using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS8080
{
    public class Stack
    {
        public ushort sp = 0;
        public Memory stack = new Memory(0x2400);

        public void Push(ushort word)
        {
            sp -= 2;
            stack.WriteWord(sp, word);
        }

        public ushort Pop()
        {
            sp += 2;
            return stack.ReadWordAt(sp - 2);
        }

        public void SetPosition(ushort position)
        {
            sp = position;
        }

        public void DumpStackPointer()
        {
            Console.Write("SP:".PadRight(15));
            Console.WriteLine("0x{0:X}", sp);
        }
    }
}
