﻿/*
 * This class contains the menu and operations available for the game
 * The other classes use to generate the menu and choose which math
 * operation to perform
 */

namespace MathGame.alexgit55
{
    internal class Enums
    {
        internal enum MainMenuOptions
        {
            PlayGame = 1,
            ViewHistory,
            Exit
        }

        internal enum GameType
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Random
        }
    }
}
