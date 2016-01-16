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
                { 0x06, mvi }



            };
        }
        
        public void nop(State state)
        {
            state.cycleCount += 4;
        }

        public void jump(State state)
        {
            state.cycleCount += 10;

            ushort address = state.memory.readWord();
            state.memory.pc = address;
        }

        public void lxi_sp(State state)
        {
            state.cycleCount += 10;

            ushort stackPointer = state.memory.readWord();
            state.stack.SetPosition(stackPointer);
        }

        public void mvi(State state)
        {
            state.cycleCount += 7;
            int dst = (state.currentOpcode >> 3) & 0x07;

            Console.WriteLine(dst);

        }
    }
}
