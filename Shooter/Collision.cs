namespace Shooter
{
    public static class Collision
    {
        public static void CheckEnemyBulletsCollision()
        {
            for (int bulletIndex = 0; bulletIndex < Player.Bullets.Count; bulletIndex++)
            {
                for (int enemyIndex = 0; enemyIndex < Enemy.Enemies.Count; enemyIndex++)
                {
                    if (
                        !UtilityMethods.DoObjectsCollide(
                            Player.Bullets[bulletIndex].Row,
                            Player.Bullets[bulletIndex].Col,
                            Enemy.Enemies[enemyIndex].Row,
                            Enemy.Enemies[enemyIndex].Col))
                    {
                        continue;
                    }

                    Player.Bullets.RemoveAt(bulletIndex);
                    Enemy.Enemies.RemoveAt(enemyIndex);
                    bulletIndex--;
                    break;
                }
            }
        }

        public static void CheckEnemyPlayerCollision()
        {
            foreach (Point t in Enemy.Enemies)
            {
                if (UtilityMethods.DoObjectsCollide(
                    t.Row,
                    t.Col,
                    Player.PlayerRow,
                    Player.PlayerCol + 2))
                {
                    Program.IsGameOver = true;
                }
            }
        }

        public static void CheckCollisions()
        {
            CheckEnemyBulletsCollision();
            CheckEnemyPlayerCollision();
        }
    }
}
