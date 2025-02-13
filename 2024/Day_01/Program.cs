using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day_01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine(FirstPart());

            Console.WriteLine(SecondPart());
        }

        public static async Task<long> FirstPart()
        {
            List<long> leftList = new();
            List<long> rightList = new();

            while (await Console.In.ReadLineAsync() is { } line)
            {
                var leftAndright = line.Split("   ");

                for (int i = 0; i < leftAndright.Length; i++)
                {
                    if (i == 0)
                    {
                        leftList.Add(long.Parse(leftAndright[i]));
                    }
                    else
                    {
                        rightList.Add(long.Parse(leftAndright[i]));
                    }
                }
            }

            rightList.Sort();
            leftList.Sort();

            long result = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                result += Math.Abs(leftList[i] - rightList[i]);
            }

            return result;
        }

        public static async Task<long> SecondPart()
        {
            List<long> leftList = new();
            List<long> rightList = new();

            while (await Console.In.ReadLineAsync() is { } line)
            {
                var leftAndright = line.Split("   ");

                for (int i = 0; i < leftAndright.Length; i++)
                {
                    if (i == 0)
                    {
                        leftList.Add(long.Parse(leftAndright[i]));
                    }
                    else
                    {
                        rightList.Add(long.Parse(leftAndright[i]));
                    }
                }
            }


            long result = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                if (rightList.Contains(leftList[i]))
                {
                    result += leftList[i] * rightList.FindAll(x => x.Equals(leftList[i])).Count;
                }
            }

            return result;
        }

    }
}