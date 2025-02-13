using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_02
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine(FirstPart());
            
            Console.WriteLine(OneTimeAintGay());
        }

        public static long FirstPart()
        {
            long result = 0;
            while (Console.In.ReadLine() is { } line)
            {
                List<long> list = new();
                var arr = line.Split(" ").ToList();

                if (AllIncreasing(arr))
                {
                    result++;
                }

                if (AllDecreasing(arr))
                {
                    result++;
                }
            }

            return result;
        }


        public static bool AllIncreasing(List<string> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr.Count - i == 1)
                {
                    break;
                }

                var diff = long.Parse(arr[i+1]) - long.Parse(arr[i]);
                if (diff < 0 || diff > 3 || diff == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AllDecreasing(List<string> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr.Count - i == 1)
                {
                    break;
                }

                var diff = long.Parse(arr[i+1]) - long.Parse(arr[i]);
                if (diff > 0 || diff < -3 || diff == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int OneTimeAintGay()
        {
            var safeCount = 0;

            while (Console.In.ReadLine() is { } line)
            {
                var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafe(report))
                {
                    safeCount++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var reportCopy = report.ToList();
                        reportCopy.RemoveAt(i);
                        if (IsSafe(reportCopy))
                        {
                            safeCount++;
                            break;
                        }
                    }
                }
            }

            var a = safeCount;
            return safeCount;
        }

        public static bool IsSafe(List<int> report)
        {
            if (report.Count < 2)
            {
                return true;
            }

            var firstDiff = report[1] - report[0];

            if (firstDiff == 0 || Math.Abs(firstDiff) > 3)
            {
                return false;
            }

            var expectedSgn = firstDiff / Math.Abs(firstDiff);

            for (int i = 1; i < report.Count - 1; i++)
            {
                var diff = report[i + 1] - report[i];
                if (diff == 0 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                var sgn = diff / Math.Abs(diff);
                if (sgn != expectedSgn)
                {
                    return false;
                }
            }

            return true;
        }

    }

}