/*
 * This class is reponsible for saving the game history for the player
 * Currently it just uses a list but would like to modify to use sqlite
 */

using Microsoft.Data.Sqlite;
using Spectre.Console;

namespace MathGame.alexgit55
{
    internal class GameHistory
    {
        private List<string[]> _history;
        private string connectionString = "Data Source=GameHistory.db";

        public GameHistory()
        {
            _history = new List<string[]>();
        }

        internal void CreateDatabase()
        // Create the database if it doesn't exist
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS GameHistory (GameType TEXT, Difficulty INTEGER, Score INTEGER, TimeElapsed TEXT)";
                command.ExecuteNonQuery();
            }
        }

        internal void SameGameToDatabase(Enum GameType, int playerScore, int difficulty, TimeSpan timeElapsed)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GameHistory (GameType, Difficulty, Score, TimeElapsed) VALUES (@GameType, @Difficulty, @Score, @TimeElapsed)";
                command.Parameters.AddWithValue("@GameType", GameType.ToString());
                command.Parameters.AddWithValue("@Difficulty", difficulty);
                command.Parameters.AddWithValue("@Score", playerScore);
                command.Parameters.AddWithValue("@TimeElapsed", timeElapsed.ToString());
                command.ExecuteNonQuery();
            }
        }

        internal void GetGameHistory()
        {
            _history.Clear();
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM GameHistory";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] gameEntry = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                            _history.Add(gameEntry);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
        }

        internal void ViewGameHistory()
        {
            GetGameHistory();
            if (_history.Count == 0)
                Console.WriteLine("\nNo history available. Please play a round of the game!");
            else
            {
                var table = new Table();
                table.AddColumn("Game Type");
                table.AddColumn("Difficulty");
                table.AddColumn("Score");
                table.AddColumn("Time Elapsed");

                foreach (var entry in _history)
                {
                    table.AddRow(entry[0], entry[1], entry[2], entry[3]);
                }

                AnsiConsole.Write(table);
            }
        }
    }
}
