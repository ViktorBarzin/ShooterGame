namespace Shooter
{
    using System;

    public static class UtilityMethods
    {
        public const int WindowWidth = 100;
        public const int WindowHeight = 15;
        public const int ScreenUpperBorder = 2;
        public const int ScreenLowerBorder = WindowHeight - 2;
        public const int EnemyStartOffset = WindowWidth;
        public const int CollisionAoe = 1;
        public static Random RandGenerator = new Random();

        public static void PrintOnPosition(int row, int col, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public static void InitialiseSettings()
        {
            Console.WindowWidth = WindowWidth;
            Console.WindowHeight = WindowHeight;
            Console.BufferWidth = WindowWidth;
            Console.BufferHeight = WindowHeight;

            Console.CursorVisible = false;
        }

        public static bool IsObjectInBounds(int row, int col)
        {
            return row >= ScreenUpperBorder &&
                   row <= WindowHeight - 1 &&
                   col >= 0 &&
                   col <= WindowWidth - 1;
        }

        public static bool DoObjectsCollide(int firstRow, int firstCol, int secondRow, int secondCol)
        {
            int colOffset = Math.Abs(firstCol - secondCol);

            return firstRow == secondRow &&
                colOffset <= CollisionAoe;
        }
    }
}
