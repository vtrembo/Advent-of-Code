using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<long> elves = new();

            long best = 0;
            long current = 0;
            while (await Console.In.ReadLineAsync() is { } line)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(current);
                    best = Math.Max(best, current);
                    current = 0;
                }
                else
                {
                    var calories = long.Parse(line);
                    current += calories;
                }
            }
            best = Math.Max(best, current);
            elves.Add(current);

            Console.WriteLine("Part 1: " + best);

            Console.WriteLine("\nPart 2: " + elves.OrderByDescending(i => i).Take(3).Sum());
        }
    }
}