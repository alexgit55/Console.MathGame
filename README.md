# Console.MathGame
My first major project for the The C# Academy

Console based Math Game application featuring several game types and a score history tracked with SQLite database

The original project has been completed already and submitted for review. The project completes all requirements and challenges listed below. 

I will keep updating the Modifications section below as I learn more about C#.

## Given Requirements:

- You need to create a Math game containing the 4 basic operations

- The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

- Users should be presented with a menu to choose an operation

- You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

- You don't need to record results on a database. Once the program is closed the results will be deleted.

## Extra Challenges

- Try to implement levels of difficulty.

- Add a timer to track how long the user takes to finish the game.

- Create a 'Random Game' option where the players will be presented with questions from random operations

- To follow the DRY Principle, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.

## Modifications

I've been continuing to modify this game to add new features as I complete more projects and learn more about C#. It's been a lot of fun revisting and enhancing the game. I'll keep track of the changes I've made here as I add functionality to the game.

- 12/19/2024 - The original game menu was a simple string menu and you entered the number of what you wanted to do.  I had to have logic here to check for an incorrect choice. The game history also only recorded into list so it wouldn't last past the current session.
  The game was modified to use the Spectre.Console library with enums for the main menu options instead. Now the player uses the up and down arrow to choose the option. This allowed me to remove the logic of checking for an incorrect choice the the choices are fixed.
  Instead of having all options displayed on the main menu, it's been modified to have the main menu just show three options of play game, view history or exit, and then the play game option will present the game type selection. I think this makes for a cleaner interface.
  I've also converted the game history to use an SQLite database so records can be saved outside of the current session.
  

## Features
- SQLite Database Connection
- This program uses an SQLite database to store and access information.
- If no database/table exists when starting the program, it will create one automatically.

## Console Based UI
- This application featues menu based navigation using the Spectre.Console library
- The main menu consists of the options to play a round of the game, view the history, or exit
- Selecting play game will bring up another menu to select which type of game you want to play (Addition, Subtraction, Multiplication, Division or Random)
- Before starting the game, you can customize it to select the number of questions and the difficulty of the game

- Here is what the original Game menu and history looked like
  ![Screenshot of the original Game Menu](https://rvnprojectstorage.blob.core.windows.net/images/Console.MathGame.Original/ConsoleMathGame_GameHistory_Original.png)

- Here's screenshots from the current menus: Main, Game Type and Settings
  |First Image|Second Image|Third Image|
  |:-:|:-:|:-:|
  |![First Image](https://rvnprojectstorage.blob.core.windows.net/images/Console.MathGame/MainMenu.png?h=750&w=1260)|![Second Image](https://rvnprojectstorage.blob.core.windows.net/images/Console.MathGame/GameType.png?h=750&w=1260)|![Third Image](https://rvnprojectstorage.blob.core.windows.net/images/Console.MathGame/GameSettings.png?h=750&w=1260)

## View Current Entries
- The main menu also offers the option to view all current entries in the database

