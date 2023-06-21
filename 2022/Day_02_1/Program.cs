using System;
using System.Threading.Tasks;

namespace Day_02_1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int total = 0;
            
            while (await Console.In.ReadLineAsync() is { } line)
            {
                total += await RockPaperScissorsRound(line);
            }

            Console.WriteLine(total);

        }

        static async Task<int> RockPaperScissorsRound(string round)
        {
            int roundPoints = 0;

            if (round.Contains('X')) // ROCK
            {
                roundPoints += 1;
                roundPoints += await ExecuteRound(round, RockPaperScissors.Rock);
            } 
            else if (round.Contains('Y')) // PAPER
            {
                roundPoints += 2;
                roundPoints += await ExecuteRound(round, RockPaperScissors.Paper);
            }
            else if(round.Contains('Z')) // SCISSORS
            {
                roundPoints += 3; 
                roundPoints += await ExecuteRound(round, RockPaperScissors.Scissors);
            }
            return roundPoints;
        }

        static async Task<int> ExecuteRound(string round, RockPaperScissors rockPaperScissors)
        {
            if (round.Contains('A')) // ROCK
            {
                switch (rockPaperScissors)
                {
                    case RockPaperScissors.Paper:
                        return 6; // WIN
                    case RockPaperScissors.Rock:
                        return 3; // DRAW
                    case RockPaperScissors.Scissors:
                        return 0; // LOSE
                }
            }

            if (round.Contains('B')) // PAPER
            {
                switch (rockPaperScissors)
                {
                    case RockPaperScissors.Paper:
                        return 3; // DRAW
                    case RockPaperScissors.Rock:
                        return 0; // LOSE
                    case RockPaperScissors.Scissors:
                        return 6; // WIN
                }
            }

            if (round.Contains('C')) // SCISSORS
            {
                switch (rockPaperScissors)
                {
                    case RockPaperScissors.Paper:
                        return 0; // LOSE
                    case RockPaperScissors.Rock:
                        return 6; // WIN
                    case RockPaperScissors.Scissors:
                        return 3; // DRAW
                }
            }

            return 0;
        }

        enum RockPaperScissors
        {
            Rock,
            Paper,
            Scissors
        }

    }
}