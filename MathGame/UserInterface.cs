/*
 * This class is responsible for running the game menu
 * It will keep running until the player chooses to exit
 */

using Spectre.Console;
using static MathGame.alexgit55.Enums;

namespace MathGame.alexgit55
{
    internal class UserInterface
    {
        internal static void MainMenu()
        {
            var history = new GameHistory();
            history.CreateDatabase();

            var keepPlayingGame = true;
            var GameMessage = "Press any key to continue";

            while (keepPlayingGame)
            {
                //Console.Clear();
                
                AnsiConsole.MarkupLine("[bold] Welcome to the Math Game![/]");
                AnsiConsole.MarkupLine("[bold] -------------------------[/]\n");

                var usersChoice = AnsiConsole.Prompt(
                   new SelectionPrompt<MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                       MainMenuOptions.PlayGame,
                       MainMenuOptions.ViewHistory,
                       MainMenuOptions.Exit
                    )
                );

                switch (usersChoice)
                {
                    case MainMenuOptions.ViewHistory:
                        Console.Clear();
                        history.ViewGameHistory();
                        break;
                    case MainMenuOptions.Exit:
                        Console.Clear();
                        Console.WriteLine("Thanks for Playing! Goodbye!");
                        GameMessage = "Press any key to exit";
                        keepPlayingGame = false;
                        break;
                    case MainMenuOptions.PlayGame:
                        Console.Clear();
                        var gameChoice = ChooseGameType();
                        Console.Clear();
                        Console.WriteLine($"You selected: {gameChoice}");
                        var GameRound = new GameRound((int)gameChoice);
                        GameRound.SetGameSettings();
                        GameRound.PlayGame();
                        history.SameGameToDatabase(gameChoice, GameRound.PlayerScore, GameRound.Difficulty, GameRound.TimeElapsed);
                        break;
                }

                Console.WriteLine(GameMessage);
                Console.ReadKey();
                Console.Clear();
            }
        }

        internal static GameType ChooseGameType()
        {
            var gameChoice = AnsiConsole.Prompt(
                new SelectionPrompt<GameType>()
                    .Title("Choose a game type")
                    .AddChoices(
                        GameType.Addition,
                        GameType.Subtraction,
                        GameType.Multiplication,
                        GameType.Division,
                        GameType.Random
                    )
            );

            return gameChoice;
        }
    }
}
