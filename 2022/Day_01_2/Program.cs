using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_01_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<long> elves = new();
            long current = 0;
            while (await Console.In.ReadLineAsync() is { } line)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(current);
                    current = 0;
                }
                else
                {
                    var calories = long.Parse(line);
                    current += calories;
                }
            }
            elves.Add(current);

            Console.WriteLine(elves.OrderByDescending(i => i).Take(3).Sum());
        }
    }
}