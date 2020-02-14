using System;

namespace func.brainfuck
{
    //This code was already in projects, no modifications were made
    public interface IVirtualMachine
	{
		void RegisterCommand(char symbol, Action<IVirtualMachine> execute);
		string Instructions { get; }
		int InstructionPointer { get; set; }
		byte[] Memory { get; }
		int MemoryPointer { get; set; }
		void Run();
	}
}