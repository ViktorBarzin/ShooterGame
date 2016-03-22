namespace Shooter
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public static int PlayerRow;
        public static int PlayerCol;
        public static string PlayerFigure = "[0>";
        public static ConsoleColor PlayerColor = ConsoleColor.Green;
        public static List<Point> Bullets = new List<Point>();

        public static void ClearPlayer()
        {
            UtilityMethods.PrintOnPosition(PlayerRow, PlayerCol, "   ", PlayerColor);
        }

        public static void DrawPlayer()
        {
            UtilityMethods.PrintOnPosition(PlayerRow, PlayerCol, PlayerFigure, PlayerColor);
        }

        public static void UpdatePlayer()
        {
            ReadInput();
        }

        public static void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (userInput.Key == ConsoleKey.LeftArrow && PlayerCol > 0)
                {
                    PlayerCol--;
                }
                else if (userInput.Key == ConsoleKey.RightArrow && PlayerCol < UtilityMethods.WindowWidth - 3)
                {
                    PlayerCol++;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && PlayerRow < UtilityMethods.ScreenLowerBorder)
                {
                    PlayerRow++;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && PlayerRow > UtilityMethods.ScreenUpperBorder)
                {
                    PlayerRow--;
                }
                else if (userInput.Key == ConsoleKey.Spacebar)
                {
                    Bullets.Add(new Point()
                    {
                        Row = PlayerRow,
                        Col = PlayerCol + 2
                    });
                }
            }
        }
    }
}
