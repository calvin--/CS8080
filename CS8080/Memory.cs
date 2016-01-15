using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS8080
{
    public class Memory
    {
        public byte[] memory;
        public int pc = 0;

        public Memory(int size)
        {
            this.memory = new byte[size];
        }

        public byte readByte()
        {
            byte value = memory[pc];
            pc++;
            return value;
        }

        public ushort readWord()
        {
            ushort value = BitConverter.ToUInt16(memory, pc);
            pc += 2;
            return value;
        }
    }
}
