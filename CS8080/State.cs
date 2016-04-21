using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

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

        public int lastInterrupt = 0x10;
        public Stopwatch timer = new Stopwatch();
        public double lastInterruptTime = 0.0f;
        public bool lol = false;

        public int port4HI = 0;
        public int port4LO = 0;
        public int port2 = 0;

        public int inp1 = 0x01;
        public int inp2 = 0x00;

        public Keys lastKey = 0;


        public void CallInstruction(byte instruction)
        {
            try
            {
                if (lol)
                {
                    DumpState();
                    Console.ReadLine();
                }

                instructions.instructions[instruction](this);
            } catch(KeyNotFoundException)
            {
                Console.WriteLine("Instruction not implemented: 0x{0:X}", instruction);
                DumpState();
                Console.ReadLine();
            }
        }

        public void LoadRom(string path)
        {
            File.ReadAllBytes(path).CopyTo(memory.memory, 0);
        }

        public void Run()
        {
            registers = new Registers(this);
            timer.Start();

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

        public void processInput(Keys key)
        {
            lastKey = key;
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
                
                int sleepTime = (int) (timer.Elapsed.TotalMilliseconds - lastInterruptTime);

                if (sleepTime < (1000/120))
                {
                    System.Threading.Thread.Sleep((1000/120)-sleepTime);
                }

                lastInterruptTime = timer.Elapsed.TotalMilliseconds;
                
            }

        }

        public void causeInterrupt()
        {
            ushort address;

            if (lastInterrupt == 0x10)
            {
                Vblank();

                switch (lastKey)
                {
                    case Keys.Left:
                        inp1 |= (1 << 5);
                        break;
                    case Keys.Right:
                        inp1 |= (1 << 6);
                        break;
                    case Keys.C:
                        inp1 |= (1 >> 0);
                        break;
                    case Keys.X:
                        inp1 |= (1 << 2);
                        break;
                    case Keys.Z:
                        inp1 |= (1 << 4);
                        break;
                    case Keys.J:
                        inp1 = 0x0;
                        break;
                    default:
                        break;

                }

                address = 0x08;
            } else
            {

                address = 0x10;
            }

            stack.Push(memory.pc);
            memory.pc = address;
            lastInterrupt = address;
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
            Console.WriteLine("0x{0:X}", memory.pc-1);
            Vblank();
        }

        public void Vblank()
        {
            var ram = memory.getVRAM();
            Array.Reverse(ram);

            GCHandle handle = GCHandle.Alloc(ram, GCHandleType.Pinned);
            IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(ram, 0);

            var bmap = new Bitmap(256, 224, 32, PixelFormat.Format1bppIndexed, ptr);
            handle.Free();
            bmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

            try
            {
                Program.form1.pictureBox1.Image = bmap;
            } catch
            {

            }
        }
    }
}