namespace Shooter
{
    using System;
    using System.Linq;

    public static class Bullets
    {
        private const string BulletFigure = "-";

        private const ConsoleColor BulletColor = ConsoleColor.Green;

        public static void ClearBullets()
        {
            foreach (Point t in Player.Bullets.Where(t => UtilityMethods.IsObjectInBounds(t.Row, t.Col)))
            {
                UtilityMethods.PrintOnPosition(t.Row, t.Col, " ", BulletColor);
            }
        }

        public static void DrawBullets()
        {
            for (int i = 0; i < Player.Bullets.Count; i++)
            {
                if (UtilityMethods.IsObjectInBounds(Player.Bullets[i].Row, Player.Bullets[i].Col))
                {
                    UtilityMethods.PrintOnPosition(Player.Bullets[i].Row, Player.Bullets[i].Col, BulletFigure, BulletColor);
                }
            }
        }

        public static void UpdateBullets()
        {
            for (int i = 0; i < Player.Bullets.Count; i++)
            {
                Player.Bullets[i].Col++;
                if (Player.Bullets[i].Col > UtilityMethods.WindowWidth - 1)
                {
                    Player.Bullets.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
