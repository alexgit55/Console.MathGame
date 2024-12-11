/*
 * This class is reponsible for running the game round
 * It's where the settings number of questions and difficulty
 * are kept as well as the how well the player did in that round
 * When the round is finished, it will call on the GameHistory 
 * class to save the round's data
 */

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
        }

        internal void SetGameDifficulty()
        {
            var difficulty = 1;
            Console.WriteLine("Enter the difficulty level (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
            {
                Console.WriteLine("Please enter a valid number between 1 and 3.");
            }

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
            var totalQuestions = 0;
            Console.WriteLine("Enter the number of questions you want to answer (1-20): ");
            while (!int.TryParse(Console.ReadLine(), out totalQuestions) || totalQuestions < 1 || totalQuestions > 20)
            {
                Console.WriteLine("Please enter a valid number between 1 and 20.");
            }

            TotalQuestions = totalQuestions;
        }

        internal void PlayGame()
        {
            StartTime = DateTime.Now;
            int operation;

            for (int i = 1; i <= TotalQuestions; i++)
            {
                if (GameType == 4)
                {
                    Random rand = new();
                    operation = rand.Next(0, 4);
                }
                else
                {
                    operation = GameType;
                }

                Console.WriteLine($"Question {i} of {TotalQuestions}");
                var question = new MathQuestion(operation,LowerRange,UpperRange);
                PlayerScore += question.GenerateMathQuestion();
                Console.Clear();
            }

            Console.WriteLine($"Your final score was {PlayerScore} out of {TotalQuestions} correct.");
            EndTime= DateTime.Now;
            TimeElapsed = EndTime - StartTime;
            Console.WriteLine($"Time Elapsed: {TimeElapsed.Minutes} minutes {TimeElapsed.Seconds} seconds");

        }
    }
}
