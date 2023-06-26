using System;
using System.Threading.Tasks;

namespace Day_04
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int contained = 0;
            int overlapped = 0;

            while (await Console.In.ReadLineAsync() is { } line)
            {

                if (await IsInInterval(line.Split(',')))
                {
                    contained++;
                }

                if (await IsOverlapping(line.Split(",")))
                {
                    overlapped++;
                }

            }

            Console.WriteLine("Part 1: " + contained);
            Console.WriteLine("\nPart 2: " + overlapped);
        }

        static async Task<bool> IsOverlapping(string[] pair)
        {
            var firstInterval = pair[0].Split('-');
            var secondInterval = pair[1].Split('-');

            if (int.Parse(firstInterval[0]) <= int.Parse(secondInterval[1]) && int.Parse(firstInterval[1]) >= int.Parse(secondInterval[0])
                ||
                int.Parse(firstInterval[1]) >= int.Parse(secondInterval[0]) && int.Parse(firstInterval[0]) <= int.Parse(secondInterval[1]))
            {
                return true;
            }

            return false;
        }

        static async Task<bool> IsInInterval(string[] pair)
        {

            var firstInterval = pair[0].Split('-');
            var secondInterval = pair[1].Split('-');

            if (int.Parse(firstInterval[0]) <= int.Parse(secondInterval[0]) 
                && int.Parse(firstInterval[1]) >= int.Parse(secondInterval[1])
                ||
            int.Parse(firstInterval[0]) >= int.Parse(secondInterval[0])
                && int.Parse(firstInterval[1]) <= int.Parse(secondInterval[1]))

            {
                return true;
            }

            return false;
        } 

    }
}