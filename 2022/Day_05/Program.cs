using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var dividerLineIndex = Array.IndexOf(lines, string.Empty);
            var numberOfStacks =
                int.Parse(lines[dividerLineIndex - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
            var stacks = new Stack<char>[numberOfStacks];

            for (int lineIndex = dividerLineIndex - 2; lineIndex >= 0; lineIndex--)
            {
                var line = lines[lineIndex];
                for (int stackId = 0; stackId < numberOfStacks; stackId++)
                {
                    var crate = line[stackId * 4 + 1];
                    if (char.IsLetter(crate))
                    {
                        stacks[stackId] ??= new Stack<char>();
                        stacks[stackId].Push(crate);
                    }
                }
            }

            var stacksAlternative = stacks;

            for (int instructionId = dividerLineIndex + 1; instructionId < lines.Length; instructionId++)
            {
                var instructions = lines[instructionId].Split(' ');
                var numberOfCrates = int.Parse(instructions[1]);
                var sourceStackId= int.Parse(instructions[3]) - 1;
                var targetStackId= int.Parse(instructions[5]) - 1;

                MoveStacks(stacks, numberOfCrates, sourceStackId, targetStackId);
                MoveStacksAlternative(stacksAlternative, numberOfCrates, sourceStackId, targetStackId);
            }

            Console.WriteLine(string.Join("", stacks.Select(s => s.Peek())));
            Console.WriteLine(string.Join("", stacksAlternative.Select(s => s.Peek())));
        }

        private static void MoveStacks(Stack<char>[] stacks, int numberOfCrates, int sourceStackId, int targetStackId)
        {
            for (int i = 0; i < numberOfCrates; i++)
            {
                var crate = stacks[sourceStackId].Pop();
                stacks[targetStackId].Push(crate);
            }
        }

        private static void MoveStacksAlternative(Stack<char>[] stacks, int numberOfCrates, int sourceStackId, int targetStackId)
        {
            var transferStack = new Stack<char>();
            for (int i = 0; i < numberOfCrates; i++)
            {
                var crate = stacks[sourceStackId].Pop();
                transferStack.Push(crate);
            }

            while (transferStack.TryPop(out var crate))
            {
                stacks[targetStackId].Push(crate);
            }

        }

    }
}