using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS8080
{
    public class Instructions
    {
        public Dictionary<byte, Action<State>> instructions;

        public Instructions()
        {
            instructions = new Dictionary<byte, Action<State>>()
            {
                { 0x00, nop },
                { 0xc3, jump },
                { 0x31, lxi_sp },

                { 0x06, mvi },
                { 0x0e, mvi },
                { 0x16, mvi },
                { 0x3e, mvi },
                { 0x1e, mvi },
                { 0x26, mvi },
                { 0x2e, mvi },
                { 0x36, mvi },


                { 0xcd, call },

                { 0x01, lxi_w },
                { 0x11, lxi_w },
                { 0x21, lxi_w },

                { 0x0a, ldax },
                { 0x1a, ldax },

                { 0x50, mov },
                { 0x51, mov },
                { 0x52, mov },
                { 0x53, mov },
                { 0x54, mov },
                { 0x55, mov },
                { 0x56, mov },
                { 0x57, mov },
                { 0x58, mov },
                { 0x59, mov },
                
                { 0x5a, mov },
                { 0x5b, mov },
                { 0x5c, mov },
                { 0x5d, mov },
                { 0x5e, mov },
                { 0x5f, mov },

                { 0x60, mov },
                { 0x61, mov },
                { 0x62, mov },
                { 0x63, mov },
                { 0x64, mov },
                { 0x65, mov },
                { 0x66, mov },
                { 0x67, mov },
                { 0x68, mov },
                { 0x69, mov },

                { 0x6a, mov },
                { 0x6b, mov },
                { 0x6c, mov },
                { 0x6d, mov },
                { 0x6e, mov },
                { 0x6f, mov },

                { 0x70, mov },
                { 0x71, mov },
                { 0x72, mov },
                { 0x73, mov },
                { 0x74, mov },
                { 0x75, mov },
                { 0x77, mov },

                { 0x78, mov },
                { 0x79, mov },
                { 0x7a, mov },
                { 0x7b, mov },
                { 0x7c, mov },
                { 0x7d, mov },
                { 0x7e, mov },
                { 0x7f, mov },

                { 0x03, inx_w },
                { 0x13, inx_w },
                { 0x23, inx_w },

                { 0x05, dcr },
                { 0x0d, dcr },
                { 0x15, dcr },
                { 0x1d, dcr },
                { 0x25, dcr },
                { 0x2d, dcr },
                { 0x3d, dcr },

                { 0xc2, jnz },

                { 0xc9, ret },

                { 0xfe, cpi },

                { 0xc5, push },
                { 0xd5, push },
                { 0xe5, push },

                { 0x09, dad },
                { 0x19, dad },
                { 0x29, dad },

                { 0xeb, xchg },

                { 0xc1, pop },
                { 0xd1, pop },
                { 0xe1, pop },

                { 0xd3, output }



            };
        }

        public void nop(State state)
        {
            state.cycleCount += 4;
        }

        public void jump(State state)
        {
            state.cycleCount += 10;

            ushort address = state.memory.ReadWord();
            state.memory.pc = address;
        }

        public void lxi_sp(State state)
        {
            state.cycleCount += 10;

            ushort stackPointer = state.memory.ReadWord();
            state.stack.SetPosition(stackPointer);
        }

        public void mvi(State state)
        {
            state.cycleCount += 7;
            byte value = state.memory.ReadByte();
            int dst = (state.currentOpcode >> 3) & 0x07;

            state.registers.WriteByte(dst, value);
        }

        public void call(State state)
        {
            state.cycleCount += 17;

            ushort address = state.memory.ReadWord();
            state.stack.Push(state.memory.pc);
            state.memory.pc = address;
        }

        public void lxi_w(State state)
        {
            state.cycleCount += 10;

            ushort value = state.memory.ReadWord();
            int dst = (state.currentOpcode >> 4) & 0x03;

            state.registers.WriteWord(dst, value);
        }

        public void ldax(State state)
        {
            state.cycleCount += 7;

            int src = (state.currentOpcode >> 4) & 0x03;
            int dst = 7; // A

            ushort address = state.registers.ReadWord(src);
            byte value = state.memory.ReadByteAt(address);

            state.registers.WriteByte(dst, value);
        }

        public void mov(State state)
        {
            state.cycleCount += 7;

            int src = (state.currentOpcode & 0x7);
            int dst = (state.currentOpcode >> 3) & 0x07;

            byte value = state.registers.ReadByte(src);

            state.registers.WriteByte(dst, value);
        }

        public void inx_w(State state)
        {
            state.cycleCount += 5;

            int dst = (state.currentOpcode >> 4) & 0x3;

            ushort value = state.registers.ReadWord(dst);
            value++;

            state.registers.WriteWord(dst, value);
        }

        public void dcr(State state)
        {
            state.cycleCount += 5;

            int dst = (state.currentOpcode >> 3) & 0x07;
            byte value = state.registers.ReadByte(dst);
            int result = value - 1;


            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY, value, result);
            state.registers.WriteByte(dst, (byte)result);
        }

        public void jnz(State state)
        {
            state.cycleCount += 10;
            ushort address = state.memory.ReadWord();

            if (!state.registers.GetFlag(Flag.ZERO)) {
                state.memory.pc = address;
            };
        }

        public void ret(State state)
        {
            state.cycleCount += 10;
            ushort address = state.stack.Pop();

            state.memory.pc = address;
        }

        public void cpi(State state)
        {
            state.cycleCount += 7;
            byte value = state.memory.ReadByte();
            byte dst = state.registers.ReadByte(7); // A

            int result = dst - value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY, value, result);
        }

        public void push(State state)
        {
            state.cycleCount += 11;

            int dst = (state.currentOpcode >> 4) & 0x3;
            ushort value = state.registers.ReadWord(dst);
            state.stack.Push(value);
        }

        public void dad(State state)
        {
            state.cycleCount += 10;

            int src = (state.currentOpcode >> 4) & 0x03;
            int dst = state.registers.ReadWord(2);

            int value = state.registers.ReadWord(src);

            int result = dst + value;

            if (result > 0xffff)
            {
                state.registers.F |= Flag.CARRY;
            } else
            {
                state.registers.F &= unchecked((byte)~Flag.CARRY);
            }

            state.registers.WriteWord(2, (ushort)result);
        }

        public void xchg(State state)
        {
            state.cycleCount += 5;

            ushort hl = state.registers.ReadWord(2);
            ushort de = state.registers.ReadWord(1);

            state.registers.WriteWord(2, de);
            state.registers.WriteWord(1, hl);
        }

        public void pop(State state)
        {
            state.cycleCount += 10;

            int dst = (state.currentOpcode >> 4) & 0x03;
            ushort value = state.stack.Pop();

            state.registers.WriteWord(dst, value);
        }

        public void output(State state) 
        {
            state.cycleCount += 10;

            byte port = state.memory.ReadByte();

            switch (port)
            {
                case 6:
                    //Watchdog?!?
                    break;
                default:
                    Console.WriteLine("Unhandled OUT {0}", port);
                    Console.ReadLine();
                    break;

            }
        }
    }
}
