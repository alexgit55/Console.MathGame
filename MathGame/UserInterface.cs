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
            var keepPlayingGame = true;
            var GameMessage = "Press any key to continue";
            AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]"));
            while (keepPlayingGame)
            {
                //Console.Clear();
                

                var usersChoice = AnsiConsole.Prompt(
                   new SelectionPrompt<Enums.MenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                       MenuOptions.Addition,
                       MenuOptions.Subtraction,
                       MenuOptions.Multiplication,
                       MenuOptions.Division,
                       MenuOptions.Random,
                       MenuOptions.History,
                       MenuOptions.Exit
                    )
                );

                switch (usersChoice)
                {
                    case MenuOptions.History:
                        Console.Clear();
                        history.ViewGameHistory();
                        break;
                    case MenuOptions.Exit:
                        Console.Clear();
                        Console.WriteLine("Thanks for Playing! Goodbye!");
                        GameMessage = "Press any key to exit";
                        keepPlayingGame = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"You selected: {usersChoice}");
                        var GameRound = new GameRound((int)usersChoice);
                        GameRound.SetGameSettings();
                        GameRound.PlayGame();
                        history.SaveGameScore(usersChoice,GameRound.PlayerScore,GameRound.Difficulty, GameRound.TimeElapsed);
                        break;
                }

                Console.WriteLine(GameMessage);
                Console.ReadKey();
            }
        }
    }
}
