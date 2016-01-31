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

                { 0xc2, jnz },

                { 0xc9, ret },

                { 0xfe, cpi }


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


            state.registers.SetFlags((byte) Flag.SIGN | (byte) Flag.ZERO | (byte) Flag.PARITY | (byte) Flag.ACARRY, value, result);
            state.registers.WriteByte(dst, (byte) result);
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

            Console.WriteLine(dst);

            int result = dst - value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY, value, result);
        }
    }
}
