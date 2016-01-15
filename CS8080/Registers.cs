using System;
using System.Runtime.InteropServices;

/// <summary>
/// Registers
/// </summary>
namespace CS8080
{
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

        public void DumpRegisters()
        {
            Console.WriteLine("B: 0x{0:X}", B);
            Console.WriteLine("C: 0x{0:X}", C);
            Console.WriteLine("D: 0x{0:X}", D);
            Console.WriteLine("E: 0x{0:X}", E);
            Console.WriteLine("H: 0x{0:X}", H);
            Console.WriteLine("L: 0x{0:X}", L);
            Console.WriteLine("F: 0x{0:X}", F);
            Console.WriteLine("A: 0x{0:X}", A);
        }
    }
}