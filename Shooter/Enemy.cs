namespace Shooter
{
    using System;
    using System.Collections.Generic;

    public static class Enemy
    {
        public const string EnemyFigure = "@";

        public const ConsoleColor EnemyColor = ConsoleColor.DarkMagenta;

        public const int EnemySpawnChance = 10;

        public static readonly List<Point> Enemies = new List<Point>();

        public static void ClearEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (UtilityMethods.IsObjectInBounds(Enemies[i].Row, Enemies[i].Col))
                {
                    UtilityMethods.PrintOnPosition(Enemies[i].Row, Enemies[i].Col, " ", EnemyColor);
                }
            }
        }

        public static void DrawEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (UtilityMethods.IsObjectInBounds(Enemies[i].Row, Enemies[i].Col))
                {
                    UtilityMethods.PrintOnPosition(Enemies[i].Row, Enemies[i].Col, EnemyFigure, EnemyColor);
                }
            }
        }

        public static void UpdateEnemies()
        {
            SpawnEnemy();

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Col--;
                if (Enemies[i].Col < 0)
                {
                    Enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void SpawnEnemy()
        {
            int chance = UtilityMethods.RandGenerator.Next(100);
            if (chance < EnemySpawnChance)
            {
                int row = UtilityMethods.RandGenerator.Next(UtilityMethods.ScreenUpperBorder, UtilityMethods.ScreenLowerBorder);
                int col = UtilityMethods.RandGenerator.Next(0, UtilityMethods.WindowWidth) + UtilityMethods.EnemyStartOffset + 20;
                Enemies.Add(new Point()
                {
                    Row = row,
                    Col = col
                });
            }
        }
    }
}
