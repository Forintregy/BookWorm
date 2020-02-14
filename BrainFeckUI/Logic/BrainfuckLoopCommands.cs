using System;
using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        static void Fill(Dictionary<int, int> bracketsIndex, IVirtualMachine vm)
        {
            string commands = vm.Instructions;
            int length = commands.Length;
            var stack = new Stack<int>();
            try
            {
                for (int i = 0; i < length; i++)
                {
                    if (commands[i] == '[') stack.Push(i);
                    if (commands[i] == ']')
                    {
                        bracketsIndex[stack.Peek()] = i;
                        bracketsIndex[i] = stack.Pop();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Твой код ломает меня :(");
            }
        }

        public static void RegisterTo(IVirtualMachine vm)
        {
            Dictionary<int, int> bracketsIndex = new Dictionary<int, int>();
            Fill(bracketsIndex, vm);
            vm.RegisterCommand('[', b =>
            {
                if (b.Memory[b.MemoryPointer] == 0)
                    vm.InstructionPointer = bracketsIndex[vm.InstructionPointer];
            });
            vm.RegisterCommand(']', b =>
            {
                if (b.Memory[b.MemoryPointer] != 0)
                    vm.InstructionPointer = bracketsIndex[vm.InstructionPointer];
            });
        }
    }
}