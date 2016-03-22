namespace Shooter
{
    using System.Threading;

    public static class Program
    {
        public static bool IsGameOver = false;

        private static void Main()
        {
            UtilityMethods.InitialiseSettings();

            while (!IsGameOver)
            {
                Clear();
                Collision.CheckCollisions();
                Update();
                Draw();

                Thread.Sleep(100);
            }
        }

        private static void Clear()
        {
            Player.ClearPlayer();
            Enemy.ClearEnemies();
            Bullets.ClearBullets();
        }

        private static void Draw()
        {
            Player.DrawPlayer();
            Enemy.DrawEnemies();
            Bullets.DrawBullets();
        }

        private static void Update()
        {
            Player.UpdatePlayer();
            Enemy.UpdateEnemies();
            Bullets.UpdateBullets();
        }
    }
}