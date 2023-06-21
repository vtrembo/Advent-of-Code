using System;
using System.Threading.Tasks;

namespace Day_02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int firstTactic = 0;
            int secondTatcic = 0;
            
            while (await Console.In.ReadLineAsync() is { } line)
            {
                firstTactic += await RockPaperScissorsFirstTactic(line);
                secondTatcic += await RockPaperScissorsSecondTactic(line);
            }

            Console.WriteLine("Part 1: " + firstTactic);
            Console.WriteLine("\nPart 2: " + secondTatcic);

        }

        static async Task<int> RockPaperScissorsFirstTactic(string round)
        {
            int roundPoints = 0;

            if (round.Contains('X')) // ROCK
            {
                roundPoints += 1;
                roundPoints += await ExecuteFirstTactic(round, RockPaperScissors.Rock);
            } 
            else if (round.Contains('Y')) // PAPER
            {
                roundPoints += 2;
                roundPoints += await ExecuteFirstTactic(round, RockPaperScissors.Paper);
            }
            else if(round.Contains('Z')) // SCISSORS
            {
                roundPoints += 3; 
                roundPoints += await ExecuteFirstTactic(round, RockPaperScissors.Scissors);
            }
            return roundPoints;
        }

        static async Task<int> ExecuteFirstTactic(string round, RockPaperScissors rockPaperScissors)
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

        static async Task<int> RockPaperScissorsSecondTactic(string round)
        {
            int roundPoints = 0;

            if (round.Contains('X')) // LOSE
            {
                roundPoints += await ExecuteSecondTactic(round, Goal.Lose);
            } 
            else if (round.Contains('Y')) // DRAW
            {
                roundPoints += 3;
                roundPoints += await ExecuteSecondTactic(round, Goal.Draw);
            }
            else if(round.Contains('Z')) // WIN
            {
                roundPoints += 6; 
                roundPoints += await ExecuteSecondTactic(round, Goal.Win);
            }
            return roundPoints;
        }

        static async Task<int> ExecuteSecondTactic(string round, Goal goal)
        {
            if (round.Contains('A')) // ROCK
            {
                switch (goal)
                {
                    case Goal.Win:
                        return 2; // PAPER
                    case Goal.Draw:
                        return 1; // ROCK
                    case Goal.Lose:
                        return 3; // SCISSORS
                }
            }

            if (round.Contains('B')) // PAPER
            {
                switch (goal)
                {
                    case Goal.Win:
                        return 3; // SCISSORS
                    case Goal.Draw:
                        return 2; // PAPER
                    case Goal.Lose:
                        return 1; // ROCK
                }
            }

            if (round.Contains('C')) // SCISSORS
            {
                switch (goal)
                {
                    case Goal.Win:
                        return 1; // ROCK
                    case Goal.Draw:
                        return 3; // SCISSORS
                    case Goal.Lose:
                        return 2; // PAPER
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

        enum Goal
        {
            Win,
            Draw,
            Lose
        }

    }
}