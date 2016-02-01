using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

/// <summary>
/// Registers
/// </summary>
namespace CS8080
{
    public static class Flag
    {
        public const byte SIGN = 1 << 7;
        public const byte ZERO = 1 << 6;
        public const byte INTERRUPT = 1 << 5;
        public const byte ACARRY = 1 << 4;
        public const byte PARITY = 1 << 2;
        public const byte CARRY = 1 << 0;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Registers
    {
        [FieldOffset(0)]
        public byte C;

        [FieldOffset(1)]
        public byte B;

        [FieldOffset(2)]
        public byte E;

        [FieldOffset(3)]
        public byte D;

        [FieldOffset(4)]
        public byte L;

        [FieldOffset(5)]
        public byte H;

        [FieldOffset(6)]
        public byte F;

        [FieldOffset(7)]
        public byte A;

        [FieldOffset(0)]
        public ushort BC;

        [FieldOffset(2)]
        public ushort DE;

        [FieldOffset(4)]
        public ushort HL;

        [FieldOffset(6)]
        public ushort AF;

        [FieldOffset(8)]
        public State state;

        public Registers(State s) : this()
        {
            state = s;
            state.parityTable = new int[] {
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
                1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1
            };
        }

        //This is all hacky due to C# being absolutely insane and converting byte (unsigned) to int (signed) whenever you do binary or arithmetic operations.
        public void SetFlags(byte mask, byte value, int result)
        {
            if((mask & Flag.ZERO) != 0)
            {
                if (result == 0)
                    F |= Flag.ZERO;
                else
                    F &= unchecked((byte) ~Flag.ZERO);
            }

            if ((mask & Flag.CARRY) != 0)
            {
                if (result < 0 || result > 255)
                    F |= Flag.CARRY;
                else
                    F &= unchecked((byte)~Flag.CARRY);
            }

            if ((mask & Flag.ACARRY) != 0)
            {
                if(false)
                {
                    F |= Flag.ACARRY;
                }
                else
                {
                    F &= unchecked((byte)~Flag.ACARRY);
                }
            }

            if ((mask & Flag.PARITY) != 0)
            {
                if (state.parityTable[(byte) result] == 1)
                    F |= Flag.PARITY;
                else
                    F &= unchecked((byte)~Flag.PARITY);
            }

            if ((mask & Flag.SIGN) != 0)
            {
                if ((result & 0x80) != 0)
                    F |= Flag.SIGN;
                else
                    F &= unchecked((byte)~Flag.SIGN);
            }
        }

        public bool GetFlag(Byte flag)
        {
            if(flag == Flag.ACARRY)
            {
                return (F & Flag.ACARRY) != 0;
            }

            if (flag == Flag.CARRY)
            {
                return (F & Flag.CARRY) != 0;
            }

            if (flag == Flag.SIGN)
            {
                return (F & Flag.SIGN) != 0;
            }

            if (flag == Flag.ZERO)
            {
                return (F & Flag.ZERO) != 0;
            }

            if (flag == Flag.PARITY)
            {
                return (F & Flag.PARITY) != 0;
            }

            return false;
        }


        public void DumpFlags()
        {
            Console.Write("ZERO:".PadRight(15));
            Console.WriteLine((F & (byte)Flag.ZERO) != 0);

            Console.Write("SIGN:".PadRight(15));
            Console.WriteLine((F & (byte)Flag.SIGN) != 0);

            Console.Write("PARITY:".PadRight(15));
            Console.WriteLine((F & (byte)Flag.PARITY) != 0);

            Console.Write("CARRY:".PadRight(15));
            Console.WriteLine((F & (byte)Flag.CARRY) != 0);

            Console.Write("ACARRY:".PadRight(15));
            Console.WriteLine((F & (byte)Flag.ACARRY) != 0);
        }

        public void DumpRegisters()
        {
            Console.Write("B:".PadRight(15));
            Console.WriteLine( "0x{0:X2}", B);

            Console.Write("C:".PadRight(15));
            Console.WriteLine("0x{0:X2}", C);

            Console.Write("D:".PadRight(15));
            Console.WriteLine("0x{0:X2}", D);

            Console.Write("E:".PadRight(15));
            Console.WriteLine("0x{0:X2}", E);

            Console.Write("H:".PadRight(15));
            Console.WriteLine("0x{0:X2}", H);

            Console.Write("L:".PadRight(15));
            Console.WriteLine("0x{0:X2}", L);

            Console.Write("A:".PadRight(15));
            Console.WriteLine("0x{0:X2}", A);

            Console.Write("F:".PadRight(15));
            Console.WriteLine("0x{0:X2}", F);
        }

        public void WriteByte(int index, byte value)
        {
            switch (index)
            {
                case 0:
                    B = value;
                    break;
                case 1:
                    C = value;
                    break;
                case 2:
                    D = value;
                    break;
                case 3:
                    E = value;
                    break;
                case 4:
                    H = value;
                    break;
                case 5:
                    L = value;
                    break;
                case 6:
                    state.memory.WriteByte(HL, value);
                    break;
                case 7:
                    A = value;
                    break;
            }
        }

        public void WriteWord(int index, ushort value)
        {
            switch (index)
            {
                case 0:
                    BC = value;
                    break;
                case 1:
                    DE = value;
                    break;
                case 2:
                    HL = value;
                    break;
                case 3:
                    AF = value;
                    break;
            }
        }

        public byte ReadByte(int index)
        {
            switch (index)
            {
                case 0:
                    return B;
                case 1:
                    return C;
                case 2:
                    return D;
                case 3:
                    return E;
                case 4:
                    return H;
                case 5:
                    return L;
                case 6:
                    return state.memory.ReadByteAt(HL);
                case 7:
                    return A;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public ushort ReadWord(int index)
        {
            switch (index)
            {
                case 0:
                    return BC;
                case 1:
                    return DE;
                case 2:
                    return HL;
                case 3:
                    return AF;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }


    }
}