using System.Text.RegularExpressions;

namespace Day_03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "input.txt"; // Change to your file path

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string content = File.ReadAllText(filePath);

            // Regex patterns for mul, do, and don't instructions
            string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            string doPattern = @"do\(\)";
            string dontPattern = @"don't\(\)";

            MatchCollection mulMatches = Regex.Matches(content, mulPattern);
            List<string> results = new List<string>();
            int totalSum = 0;
            bool mulEnabled = true;

            // Process input sequentially to track do() and don't() states
            foreach (Match match in Regex.Matches(content, @"do\(\)|don't\(\)|mul\(\d{1,3},\d{1,3}\)"))
            {
                string token = match.Value;
                if (token == "do()")
                {
                    mulEnabled = true;
                }
                else if (token == "don't()") 
                {
                    mulEnabled = false;
                }
                else if (token.StartsWith("mul"))
                {
                    if (mulEnabled)
                    {
                        Match mulMatch = Regex.Match(token, mulPattern);
                        if (mulMatch.Success)
                        {
                            int num1 = int.Parse(mulMatch.Groups[1].Value);
                            int num2 = int.Parse(mulMatch.Groups[2].Value);
                            totalSum += num1 * num2;
                            results.Add(token);
                        }
                    }
                }
            }

            // Convert list to array
            string[] mulArray = results.ToArray();

            // Output result
            Console.WriteLine("Extracted mul expressions:");
            foreach (var item in mulArray)
            {
                Console.WriteLine(item);
            }

            // Output total sum
            Console.WriteLine($"Total Sum: {totalSum}");

        }
    }
}
