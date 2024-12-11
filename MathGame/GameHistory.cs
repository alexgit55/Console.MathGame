/*
 * This class is reponsible for saving the game history for the player
 * Currently it just uses a list but would like to modify to use sqlite
 */

namespace MathGame.alexgit55
{
    internal class GameHistory
    {
        private List<string> _history;

        public GameHistory()
        {
            _history = new List<string>();
        }

        internal void SaveGameScore(Enum GameType, int playerScore, int difficulty, TimeSpan timeElapsed)
        // Save the player's score for the round in the game history
        {
            string historyEntry = "";

            historyEntry = $"GameType: {GameType}, difficulty: {difficulty}, Score: {playerScore} points, Time Elapsed: {timeElapsed.Minutes} minutes {timeElapsed.Seconds} seconds";
            _history.Add(historyEntry);
        }
        internal void ViewGameHistory()
        // Display scores from each round played
        {
            if (_history.Count == 0)
                Console.WriteLine("\nNo history available. Please play a round of the game!");
            else
            {
                Console.WriteLine("\nGame History");
                Console.WriteLine("-------------");
                for (int i = 0; i < _history.Count; i++)
                {
                    Console.WriteLine($"Round {i + 1}: {_history[i]}");
                }
            }
        }
    }
}
