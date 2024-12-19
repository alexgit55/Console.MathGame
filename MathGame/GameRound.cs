/*
 * This class is reponsible for running the game round
 * It's where the settings number of questions and difficulty
 * are kept as well as the how well the player did in that round
 * When the round is finished, it will call on the GameHistory 
 * class to save the round's data
 */

using Spectre.Console;

namespace MathGame.alexgit55
{
    internal class GameRound
    {
        internal int TotalQuestions { get; set; }
        internal int LowerRange { get; set; }
        internal int UpperRange { get; set; }
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal TimeSpan TimeElapsed { get; set; }
        internal int GameType { get; set; }
        internal int PlayerScore { get; set; }
        internal int Difficulty { get; set; }

        internal GameRound() { }

        public GameRound(int gameType)
        {
            LowerRange = 2;
            UpperRange = 10;
            TotalQuestions = 10;
            GameType = gameType;
            PlayerScore = 0;
            Difficulty = 1;
        }

        internal void SetGameSettings()
        {
            Console.WriteLine();
            Console.WriteLine("Now, let's customize your game settings...");
            SetTotalQuestions();
            SetGameDifficulty();

            AnsiConsole.MarkupLine($"[bold]You have chosen to play {TotalQuestions} questions with a difficulty of {Difficulty}[/]\n");
            AnsiConsole.MarkupLine($"All Set!\n");
            AnsiConsole.MarkupLine($"Press any key to start the game...");
            Console.ReadKey();
            Console.Clear();
        }

        internal void SetGameDifficulty()
        {
            var difficulty = AnsiConsole.Prompt(
                new TextPrompt<int>($"Select the game difficulty (1-3)")
                    .DefaultValue(2)
                    .Validate(gameDifficulty =>
                    {
                        if (gameDifficulty < 1 || gameDifficulty > 3)
                            return ValidationResult.Error("Please enter a number between 1 and 3.");
                        return ValidationResult.Success();
                    })
            );

            Difficulty = difficulty;

            switch (Difficulty)
            {
                case 1:
                    UpperRange = 10;
                    break;
                case 2:
                    UpperRange = 30;
                    break;
                case 3:
                    UpperRange = 50;
                    break;
            }
        }

        internal void SetTotalQuestions()
        {
            var totalQuestions = AnsiConsole.Prompt(
                new TextPrompt<int>($"Enter the number of questions you would like to answer (1-20)")
                    .DefaultValue(10)
                    .Validate(question =>
                    {
                        if (question < 1 || question > 20)
                            return ValidationResult.Error("Please enter a number between 1 and 20.");
                        return ValidationResult.Success();
                    })
            );

            TotalQuestions = totalQuestions;
        }

        internal void PlayGame()
        {
            StartTime = DateTime.Now;
            int operation=GameType;

            for (int i = 1; i <= TotalQuestions; i++)
            {
                if (GameType == 4)
                {
                    Random rand = new();
                    operation = rand.Next(0, 4);
                }

                Console.WriteLine($"Question {i} of {TotalQuestions}");
                var question = new MathQuestion(operation,LowerRange,UpperRange);
                PlayerScore += question.GenerateMathQuestion();
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Your final score was {PlayerScore} out of {TotalQuestions} correct.");
            EndTime= DateTime.Now;
            TimeElapsed = EndTime - StartTime;
            Console.WriteLine($"Time Elapsed: {TimeElapsed.Minutes} minutes {TimeElapsed.Seconds} seconds");

        }
    }
}
