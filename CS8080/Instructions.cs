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
                { 0x40, mov },
                { 0x41, mov },
                { 0x42, mov },
                { 0x43, mov },
                { 0x44, mov },
                { 0x45, mov },
                { 0x46, mov },
                { 0x47, mov },
                { 0x48, mov },
                { 0x49, mov },
                { 0x4a, mov },
                { 0x4b, mov },
                { 0x4c, mov },
                { 0x4d, mov },
                { 0x4e, mov },
                { 0x4f, mov },
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
                { 0x35, dcr },

                { 0x04, inr },
                { 0x0c, inr },
                { 0x14, inr },
                { 0x1c, inr },
                { 0x24, inr },
                { 0x2c, inr },
                { 0x34, inr },
                { 0x3c, inr },

                { 0x80, add },
                { 0x81, add },
                { 0x82, add },
                { 0x83, add },
                { 0x84, add },
                { 0x85, add },
                { 0x86, add },
                { 0x87, add },

                { 0xc2, jnz },
                { 0xc9, ret },
                { 0xfe, cpi },
                { 0xc5, push },
                { 0xd5, push },
                { 0xe5, push },
                { 0xf5, push },
                { 0x09, dad },
                { 0x19, dad },
                { 0x29, dad },
                { 0xeb, xchg },
                { 0xc1, pop },
                { 0xd1, pop },
                { 0xe1, pop },
                { 0xf1, pop },
                { 0xd3, output },
                { 0xfb, ei },
                { 0xdb, input },
                { 0x0f, rrc },
                { 0xe6, ani },
                { 0xc6, adi },
                { 0x3a, lda },
                { 0x32, sta },
                { 0xa8, xra},
                { 0xa9, xra},
                { 0xaa, xra},
                { 0xab, xra},
                { 0xac, xra},
                { 0xad, xra},
                { 0xae, xra},
                { 0xaf, xra},
                { 0xa0, ana},
                { 0xa1, ana},
                { 0xa2, ana},
                { 0xa3, ana},
                { 0xa4, ana},
                { 0xa5, ana},
                { 0xa6, ana},
                { 0xa7, ana},
                { 0xb0, ora},
                { 0xb1, ora},
                { 0xb2, ora},
                { 0xb3, ora},
                { 0xb4, ora},
                { 0xb5, ora},
                { 0xb6, ora},
                { 0xb7, ora},
                { 0xca, jz },
                { 0xfa, jm },
                { 0xd2, jnc },
                { 0xc4, cnz },
                { 0xc8, rz },
                { 0xda, jc },
                { 0x37, stc },
                { 0xd8, rc },
                { 0xe3, xthl },
                { 0xe9, pchl },
                { 0xc0, rnz },
                { 0xd0, rnc },
                { 0x0b, dcx },
                { 0x1b, dcx },
                { 0x2b, dcx },
                { 0x3b, dcx },
                { 0xd6, sui },
                { 0x07, rlc },
                { 0x2a, lhld },
                { 0x1f, rar },
                { 0xf6, ori },
                { 0x22, shld },
                { 0xcc, cz },
                { 0xde, sbi },
                { 0x2f, cma },

                { 0xb8, cmp },
                { 0xb9, cmp },
                { 0xba, cmp },
                { 0xbb, cmp },
                { 0xbc, cmp },
                { 0xbd, cmp },
                { 0xbe, cmp },
                { 0xbf, cmp },

                { 0xd4, cnc },

                { 0x90, sub },
                { 0x91, sub },
                { 0x92, sub },
                { 0x93, sub },
                { 0x94, sub },
                { 0x95, sub },
                { 0x96, sub },
                { 0x97, sub },

                { 0x02, stax },
                { 0x12, stax },
                { 0x27, daa },
                { 0x88, adc },
                { 0x89, adc },
                { 0x8a, adc },
                { 0x8b, adc },
                { 0x8c, adc },
                { 0x8d, adc },
                { 0x8e, adc },
                { 0x8f, adc },

             };
        }

        public void nop(State state)
        {
            state.cycleCount += 4;
        }

        public void stax(State state)
        {
            state.cycleCount += 7;

            int src = (state.currentOpcode >> 4) & 0x03;
            int dst = 7; // A

            ushort address = state.registers.ReadWord(src);
            byte value = state.registers.ReadByte(dst);

            state.memory.WriteByte(address, value);
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

        public void inr(State state)
        {
            state.cycleCount += 5;

            int dst = (state.currentOpcode >> 3) & 0x07;
            byte value = state.registers.ReadByte(dst);
            int result = value + 1;


            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, value, result);
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

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, value, result);
        }

        public void push(State state)
        {
            state.cycleCount += 11;

            int src = (state.currentOpcode >> 4) & 0x3;
            ushort value = state.registers.ReadWord(src);

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

        public void rrc(State state)
        {
            state.cycleCount += 4;

            if((state.registers.A & 1) != 0)
            {
                state.registers.F |= Flag.CARRY;
            } else
            {
                state.registers.F &= unchecked((byte)~Flag.CARRY);
            }

            int result = (state.registers.A >> 1) | ((state.registers.F & Flag.CARRY) << 7 );

            state.registers.A = (byte)result;
        }

        public void ani(State state)
        {
            state.cycleCount += 7;
            byte value = state.memory.ReadByte();

            int result = state.registers.A & value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, value, result);

            state.registers.A = (byte)result;
        }

        public void adi(State state)
        {
            state.cycleCount += 7;
            byte value = state.memory.ReadByte();

            int result = state.registers.A + value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, value, result);

            state.registers.A = (byte)result;
        }

        public void adc(State state)
        {
            state.cycleCount += 4;
            int src = (state.currentOpcode & 0x7);
            byte value = state.registers.ReadByte(src);

            int result = state.registers.A + value + (state.registers.F & (byte)Flag.CARRY);
            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, value, result);

            state.registers.A = (byte)result;
        }

        public void lda(State state)
        {
            state.cycleCount += 13;
            ushort address = state.memory.ReadWord();
            byte value = state.memory.ReadByteAt(address);

            state.registers.A = value;
        }

        public void sta(State state)
        {
            state.cycleCount += 13;
            ushort address = state.memory.ReadWord();

            state.memory.WriteByte(address, state.registers.A);
        }

        public void xra(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);

            byte value = state.registers.ReadByte(src);
            int result = state.registers.A ^ value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte)result;
        }

        public void ana(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);

            byte value = state.registers.ReadByte(src);
            int result = state.registers.A & value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte)result;
        }

        public void add(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);

            byte value = state.registers.ReadByte(src);
            int result = state.registers.A + value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte)result;
        }

        public void sub(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);

            byte value = state.registers.ReadByte(src);
            int result = state.registers.A - value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte)result;
        }

        public void ora(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);

            byte value = state.registers.ReadByte(src);
            int result = state.registers.A | value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte)result;
        }


        public void input(State state)
        {
            state.cycleCount += 10;
            byte port = state.memory.ReadByte();

            switch (port)
            {
                case 1:
                    state.registers.A = (byte)state.inp1;
                    break;
                case 2:
                    state.registers.A = (byte)state.inp2;
                    break;
                case 3:
                    state.registers.A = (byte)((((state.port4HI << 8) | state.port4LO) << state.port2) >> 8);
                    break;
                default:
                    break;
            }
        }

        public void output(State state)
        {
            state.cycleCount += 10;

            byte port = state.memory.ReadByte();

            switch (port)
            {
                case 2:
                    state.port2 = state.registers.A;
                    break;
                case 3:
                    if (((state.registers.A & (1 << 3)) > 0) && ((state.port3o & (1 << 3)) == 0))
                    {
                        state.soundInvaderKilled.Play();
                    }

                    state.port3o = state.registers.A;
                    break;
                case 4:
                    state.port4LO = state.port4HI;
                    state.port4HI = state.registers.A;
                    break;
                case 5:

                    break;
                case 6:
                    //Watchdog?!?
                    break;
                default:
                    state.DumpState();
                    Console.WriteLine("Unhandled OUT {0}", port);
                    Console.ReadLine();
                    break;

            }
        }

        public void ei(State state)
        {
            state.cycleCount += 4;
            state.registers.F |= Flag.INTERRUPT;
        }

        public void jz(State state)
        {

            state.cycleCount += 10;

            ushort address = state.memory.ReadWord();

            if (state.registers.GetFlag(Flag.ZERO))
            {
                state.memory.pc = address;
            }
        }

        public void jm(State state)
        {

            state.cycleCount += 10;

            ushort address = state.memory.ReadWord();

            if (state.registers.GetFlag(Flag.SIGN))
            {
                state.memory.pc = address;
            }
        }

        public void jnc(State state)
        {
            state.cycleCount += 10;

            ushort address = state.memory.ReadWord();

            if (!state.registers.GetFlag(Flag.CARRY))
            {
                state.memory.pc = address;
            }
        }

        public void jc(State state)
        {
            state.cycleCount += 10;

            ushort address = state.memory.ReadWord();

            if (state.registers.GetFlag(Flag.CARRY))
            {
                state.memory.pc = address;
            }
        }

        /*
        This BCD stuff is like black magic to me, implemented by looking at similar emulators.
        */
        public void daa(State state)
        {
            int top4 = (state.registers.A >> 4) & 0xf;
            int bot4 = (state.registers.A & 0xf);

            if ((bot4 > 9) || ((state.registers.F & (int)Flag.CARRY) > 0)) {
                state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, state.registers.A + 6);
                state.registers.A += 6;
                top4 = (state.registers.A >> 4) & 0xF;
                bot4 = (state.registers.A & 0xf);
            }

            if((top4 > 9) || ((state.registers.F & (int)Flag.CARRY) > 0))
            {
                top4 += 6;
                state.registers.A = (byte)((top4 << 4) | bot4);
            }
        }

        public void rz(State state)
        {
            if (state.registers.GetFlag(Flag.ZERO))
            {
                state.cycleCount += 1;
                ret(state);
            } else
            {
                state.cycleCount += 5;
            }
        }

        public void rnz(State state)
        {
            if (!state.registers.GetFlag(Flag.ZERO))
            {
                state.cycleCount += 1;
                ret(state);
            }
            else
            {
                state.cycleCount += 5;
            }
        }

        public void rnc(State state)
        {
            if (!state.registers.GetFlag(Flag.CARRY))
            {
                state.cycleCount += 1;
                ret(state);
            }
            else
            {
                state.cycleCount += 5;
            }
        }

        public void stc(State state)
        {
            state.cycleCount += 4;
            state.registers.F |= Flag.CARRY;
        }

        public void rc(State state)
        {
            if (state.registers.GetFlag(Flag.CARRY))
            {
                state.cycleCount += 1;
                ret(state);
            }
            else
            {
                state.cycleCount += 5;
            }
        }

        public void xthl(State state)
        {
            state.cycleCount += 18;

            ushort value = state.stack.Pop();
            state.stack.Push(state.registers.HL);
            state.registers.HL = value;
        }

        public void pchl(State state)
        {
            state.cycleCount += 5;

            state.memory.pc = state.registers.HL;
        }

        public void dcx(State state)
        {
            state.cycleCount += 5;
            int dst = (state.currentOpcode >> 4) & 0x03;

            int value = state.registers.ReadWord(dst);
            int result = value - 1;

            state.registers.WriteWord(dst, (ushort) result);
        }

        public void sui(State state)
        {
            state.cycleCount += 7;

            byte value = state.memory.ReadByte();
            int result = state.registers.A - value;
            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte) result;
        }

        public void rlc(State state)
        {
            state.cycleCount += 4;

            if (((int)state.registers.A & (1 << 7)) != 0)
            {
                state.registers.F |= Flag.CARRY;
            }
            else
            {
                state.registers.F &= unchecked((byte)~Flag.CARRY);
            }

            int result = (state.registers.A << 1) | (state.registers.F & Flag.CARRY);

            state.registers.A = (byte)result;
        }

        public void cnz(State state)
        {
            if (!state.registers.GetFlag(Flag.ZERO))
            {
                call(state);
            }
            else
            {
                state.memory.pc += 2;
                state.cycleCount += 11;
            }
        }

        public void cnc(State state)
        {
            if (!state.registers.GetFlag(Flag.CARRY))
            {
                call(state);
            }
            else
            {
                state.memory.pc += 2;
                state.cycleCount += 11;
            }
        }

        public void cz(State state)
        {
            if (state.registers.GetFlag(Flag.ZERO))
            {
                call(state);
            }
            else
            {
                state.memory.pc += 2;
                state.cycleCount += 11;
            }
        }

        public void lhld(State state)
        {
            state.cycleCount += 16;

            ushort address = state.memory.ReadWord();
            ushort value = state.memory.ReadWordAt(address);

            state.registers.HL = value;
        }

        public void rar(State state)
        {
            state.cycleCount += 4;

            /*
            byte bit1 = (byte)(state.registers.A & 0x1);
            state.registers.A = (byte)((state.registers.A >> 1) | ((state.registers.F & Flag.CARRY) << 7));

            if (bit1 != 0)
            {
                state.registers.F |= Flag.CARRY;
            }
            else
            {
                state.registers.F &= unchecked((byte)~Flag.CARRY);
            }*/

            int temp = state.registers.A & 0xff;

            state.registers.A >>= 1;

            if((state.registers.F & Flag.CARRY) > 0)
            {
                state.registers.A |= 0x80;
            }

            if((temp & 1) > 0)
            {
                state.registers.F |= Flag.CARRY;
            } else
            {
                state.registers.F &= unchecked((byte)~Flag.CARRY);
            }
        }   

        public void ori(State state)
        {
            state.cycleCount += 7;

            byte value = state.memory.ReadByte();
            int result = state.registers.A | value;

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte) result;
        }

        public void shld(State state)
        {
            state.cycleCount += 16;

            ushort address = state.memory.ReadWord();
            state.memory.WriteWord(address, state.registers.HL);
        }

        public void sbi(State state)
        {
            state.cycleCount += 7;
            int result;
            byte value = state.memory.ReadByte();
            
            if((state.registers.F & Flag.CARRY) != 0)
            {
                result = state.registers.A - (value - 1);
            } else
            {
                result = state.registers.A - value;
            }

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);

            state.registers.A = (byte) result;
        }

        public void cma(State state)
        {
            state.cycleCount += 4;

            state.registers.A = (byte) ~(state.registers.A);
        }

        public void cmp(State state)
        {
            state.cycleCount += 4;

            int src = (state.currentOpcode & 0x7);
            int result = state.registers.A - state.registers.ReadByte(src);

            state.registers.SetFlags((byte)Flag.SIGN | (byte)Flag.ZERO | (byte)Flag.PARITY | (byte)Flag.ACARRY | (byte)Flag.CARRY, state.registers.A, result);
        }
    }
}
