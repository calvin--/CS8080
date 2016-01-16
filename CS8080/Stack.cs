using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS8080
{
    public class Stack
    {
        public int stackPointer = 0;
        public Memory stack = new Memory(64 * 1000);

        public void Push(ushort word)
        {
            stackPointer -= 2;
            stack.writeWord(stackPointer, word);
        }

        public ushort Pop()
        {
            stackPointer += 2;
            return stack.readWordAt(stackPointer - 2);
        }

        public void SetPosition(int position)
        {
            stackPointer = position;
        }

        public void DumpStackPointer()
        {
            Console.WriteLine("SP: 0x{0:X}", stackPointer);
        }
    }
}
