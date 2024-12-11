
namespace MathGame.alexgit55
{
    internal class GameSettings
    {

        internal int TotalQuestions { get; set; }
        internal int LowerRange { get; set; }
        internal int UpperRange { get; set; }

        public GameSettings() 
        {
            LowerRange = 1;
            UpperRange = 10;
            TotalQuestions = 10;
        }

        internal void SetGameSettings()
        {
            Console.Clear();
            Console.WriteLine("Custom Game Settings");
            Console.WriteLine("--------------------");
            SetTotalQuestions();
            SetGameDifficulty();
        }

        private void SetGameDifficulty()
        {
            var difficulty = 1;
            Console.WriteLine("Enter the difficulty level (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
            {
                Console.WriteLine("Please enter a valid number between 1 and 3.");
            }

            switch (difficulty)
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

        private void SetTotalQuestions()
        {
            var totalQuestions=0;
            Console.WriteLine("Enter the number of questions you want to answer (1-20): ");
            while (!int.TryParse(Console.ReadLine(), out totalQuestions) || totalQuestions < 1 || totalQuestions > 20)
            {
                Console.WriteLine("Please enter a valid number between 1 and 20.");
            }

            TotalQuestions=totalQuestions;
        }
    }
}
