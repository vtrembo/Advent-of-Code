using System;
using System.Threading.Tasks;

namespace Day_03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int firstTotal = 0;
            int secondTotal = 0;

            int lineNumber = 0;
            string[] elves = new string[2];
            while (await Console.In.ReadLineAsync() is { } line)
            {
                firstTotal += await CalculatePriorities(line);

                if (lineNumber != 0 && lineNumber % 2 == 0)
                {
                    foreach (var item in line)
                    {
                        if (elves[0].Contains(item) && elves[1].Contains(item))
                        {
                            secondTotal += await CalculateItemPriority(item);
                            break;
                        }
                    }
                    lineNumber = 0;
                    continue;
                }
                elves[lineNumber] = line;
                lineNumber += 1;

            }
            
            Console.WriteLine("Part 1: " + firstTotal);
            Console.WriteLine("\nPart 2: " + secondTotal);

        }

        static async Task<int> CalculatePriorities(string backpack)
        {
            string firstCompartment = backpack[..(backpack.Length / 2)];
            string secondCompartment = backpack.Substring(backpack.Length/2);

            foreach (var item in firstCompartment)
            {
                if (secondCompartment.Contains(item))
                {
                    return await CalculateItemPriority(item);
                }
            }

            return 0;
        }

        static async Task<int> CalculateItemPriority(char item)
        {
            if (char.IsUpper(item))
            {
                return item - 38; // So A-Z starts from 27
            }
            return item - 96; // So a-z starts from 1
        }

    }
}