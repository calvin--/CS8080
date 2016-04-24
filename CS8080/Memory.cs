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
        public ushort pc = 0;

        public Memory(int size)
        {
            memory = new byte[size];
        }

        public byte ReadByte()
        {
            byte value = memory[pc];
            pc++;
            return value;
        }

        public byte ReadByteAt(int position)
        {
            return memory[position];
        }

        public ushort ReadWord()
        {
            ushort value = BitConverter.ToUInt16(memory, pc);
            pc += 2;
            return value;
        }

        public ushort ReadWordAt(int position)
        {
            return BitConverter.ToUInt16(memory, position);
        }

        public void WriteByte(int position, byte value)
        {
            memory[position] = value;
        }

        public void WriteWord(int position, ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            memory[position] = bytes[0];
            memory[position + 1] = bytes[1];
        }

        public byte[] GetVRAM()
        {
            return memory.Skip<byte>(0x2400).Take<byte>(0x4000 - 0x2400).ToArray();
        }

    }
}
