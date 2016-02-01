using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS8080
{
    public class State
    {
        public Memory memory = new Memory(64 * 1000);
        public Registers registers;
        public Instructions instructions = new Instructions();
        public Stack stack = new Stack();
        public byte currentOpcode = 0;

        public int sp = 0;
        public int cycleCount = 0;
        public int opCount = 0;
        public int[] parityTable;

        public ushort shiftRegister = 0x0000;
        public ushort shifOffset = 0x0000;

        public int lastInterrupt = 0x10;

        public void CallInstruction(byte instruction)
        {
            try
            {
                //Console.WriteLine("{0}: 0x{1:X}", opCount, instruction);

                if(false && opCount > 1552)
                {
                    Console.ReadLine();
                    DumpState();
                }

                instructions.instructions[instruction](this);
            } catch(KeyNotFoundException)
            {
                Console.WriteLine("Instruction not implemented: 0x{0:X}", instruction);
                DumpState();

                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }

        public void LoadRom(string path)
        {
            File.ReadAllBytes(path).CopyTo(memory.memory, 0);
        }

        public void Run()
        {
            registers = new Registers(this);
            while (true)
            {
                processInterrupt();
                opCount += 1;
                NextInstruction();
            }
        }

        public void NextInstruction()
        {
            byte opcode = memory.ReadByte();
            currentOpcode = opcode;
            CallInstruction(opcode);
        }

        public void processInterrupt()
        {
            if(cycleCount > 16667)
            {
                cycleCount -= 16667;

                if((registers.F & Flag.INTERRUPT) != 0)
                {
                    causeInterrupt();
                }
            }
        }

        public void causeInterrupt()
        {
            ushort address;

            if(lastInterrupt == 0x10)
            {
                address = 0x08;
            } else
            {
                address = 0x10;
            }

            stack.Push(memory.pc);
            memory.pc = address;
        }

        public void DumpState()
        {
            Console.Write("Opcount:".PadRight(15));
            Console.WriteLine("{0}", opCount);
            Console.Write("Cyclecount:".PadRight(15));
            Console.WriteLine("{0}", cycleCount);
            registers.DumpRegisters();
            stack.DumpStackPointer();
            registers.DumpFlags();
            Console.Write("PC:".PadRight(15));
            Console.WriteLine("0x{0:X}", memory.pc);
        }
    }
}