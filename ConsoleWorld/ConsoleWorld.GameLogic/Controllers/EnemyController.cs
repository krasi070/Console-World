namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Enums;
    using Models.Enemies;
    using System;

    public class EnemyController
    {
        private Random random;

        public EnemyController()
        {
            this.random = new Random();
        }

        public void MoveEnemy(Dungeon dungeon, Enemy enemy)
        {
            Direction direction = (Direction)random.Next(4);
            switch (direction)
            {
                case Direction.North:
                    Tile tile = dungeon.GetTile(enemy.X, enemy.Y - 1);
                    if (tile.IsFree)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.Y--;
                        tile.IsEnemy = true;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                    }
                    break;
                case Direction.South:
                    tile = dungeon.GetTile(enemy.X, enemy.Y + 1);
                    if (tile.IsFree)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.Y++;
                        tile.IsEnemy = true;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                    }
                    break;
                case Direction.West:
                    tile = dungeon.GetTile(enemy.X + 1, enemy.Y);
                    if (tile.IsFree)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.X++;
                        tile.IsEnemy = true;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                    }
                    break;
                case Direction.East:
                    tile = dungeon.GetTile(enemy.X - 1, enemy.Y);
                    if (tile.IsFree)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.X--;
                        tile.IsEnemy = true;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                    }
                    break;
            }
        }
    }
}