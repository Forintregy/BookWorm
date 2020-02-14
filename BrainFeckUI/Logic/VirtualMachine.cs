using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
        public string Instructions { get; }
        private Dictionary<char, Action<IVirtualMachine>> Commands;
        public int InstructionPointer { get; set; }
        public byte[] Memory { get; }
        public int MemoryPointer { get; set; }


        public VirtualMachine(string program, int memorySize)
		{
            Memory = new byte[memorySize];
            Instructions = program;
            MemoryPointer = 0;
            InstructionPointer = 0;
            Commands = new Dictionary<char, Action<IVirtualMachine>>();
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            Commands[symbol] = execute;
        }

		public void Run()
		{
            Action<IVirtualMachine> action;
            for (; InstructionPointer < Instructions.Length; InstructionPointer++)
            {
                if (Commands.ContainsKey(Instructions[InstructionPointer]))
                {
                    action = Commands[Instructions[InstructionPointer]];
                    action(this);
                }
            }
		}
	}
}