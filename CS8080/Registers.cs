using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

/// <summary>
/// Registers
/// </summary>
namespace CS8080
{
    public enum Flag
    {
        SIGN = 1 << 7,
        ZERO = 1 << 6,
        ACARRY = 1 << 4,
        PARITY = 1 << 2,
        CARRY = 1 << 0
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
        }

        public void SetFlags(byte mask)
        {
            if((mask & (byte) (Flag.ZERO)) != 0)
            {
                F |= (byte) Flag.ZERO;
            }

            if ((mask & (byte) (Flag.CARRY)) != 0)
            {
                F |= (byte) Flag.ZERO;
            }

            if ((mask & (byte) (Flag.ACARRY)) != 0)
            {
                F |= (byte) Flag.ZERO;
            }

            if ((mask & (byte) (Flag.PARITY)) != 0)
            {
                F |= (byte) Flag.ZERO;
            }

            if ((mask & (byte)(Flag.SIGN)) != 0)
            {
                F |= (byte) Flag.ZERO;
            }
        }

        public void DumpFlags()
        {
            Console.WriteLine("ZERO: {0}", (F & (byte) Flag.ZERO) != 0);
        }

        public void DumpRegisters()
        {
            Console.WriteLine("B: 0x{0:X}", B);
            Console.WriteLine("C: 0x{0:X}", C);
            Console.WriteLine("D: 0x{0:X}", D);
            Console.WriteLine("E: 0x{0:X}", E);
            Console.WriteLine("H: 0x{0:X}", H);
            Console.WriteLine("L: 0x{0:X}", L);
            Console.WriteLine("A: 0x{0:X}", A);
            Console.WriteLine("F: 0x{0:X}", F);
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