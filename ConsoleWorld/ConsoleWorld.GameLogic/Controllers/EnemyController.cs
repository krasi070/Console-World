namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Enums;
    using Models.Enemies;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Models;
    using Handler;

    public class EnemyController
    {
        private const int AttackChance = 80;

        private Random random;
        private MessageHandler messageHandler;

        public EnemyController()
        {
            this.random = new Random();
            this.messageHandler = new MessageHandler();
        }

        public bool Action(Dungeon dungeon, Enemy enemy, Character character)
        {
            if (random.Next(100) < AttackChance)
            {
                if (!this.ExecuteAttack(enemy, dungeon, character))
                {
                    this.MoveEnemy(dungeon, enemy);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                this.MoveEnemy(dungeon, enemy);
            }

            return false;
        }

        public void MoveEnemy(Dungeon dungeon, Enemy enemy)
        {
            int index = enemy.X + enemy.Y * dungeon.Width;
            Direction direction = (Direction)random.Next(4);
            switch (direction)
            {
                case Direction.North:
                    Tile tile = dungeon.GetTile(enemy.X, enemy.Y - 1);
                    if (tile.IsFree && !tile.IsPlayer)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.GetTile(enemy.X, enemy.Y).IsFree = true;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.Y--;
                        tile.IsEnemy = true;
                        tile.IsFree = false;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                        else
                        {
                            enemy.IsVisible = false;
                        }
                    }                   
                    break;
                case Direction.South:
                    tile = dungeon.GetTile(enemy.X, enemy.Y + 1);
                    if (tile.IsFree && !tile.IsPlayer)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.GetTile(enemy.X, enemy.Y).IsFree = true;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.Y++;
                        tile.IsEnemy = true;
                        tile.IsFree = false;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                        else
                        {
                            enemy.IsVisible = false;
                        }
                    }
                    break;
                case Direction.West:
                    tile = dungeon.GetTile(enemy.X + 1, enemy.Y);
                    if (tile.IsFree && !tile.IsPlayer)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.GetTile(enemy.X, enemy.Y).IsFree = true;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.X++;
                        tile.IsEnemy = true;
                        tile.IsFree = false;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                        else
                        {
                            enemy.IsVisible = false;
                        }
                    }
                    break;
                case Direction.East:
                    tile = dungeon.GetTile(enemy.X - 1, enemy.Y);
                    if (tile.IsFree && !tile.IsPlayer)
                    {
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        dungeon.GetTile(enemy.X, enemy.Y).IsFree = true;
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        enemy.X--;
                        tile.IsEnemy = true;
                        tile.IsFree = false;
                        if (tile.IsVisibe)
                        {
                            enemy.Draw();
                        }
                        else
                        {
                            enemy.IsVisible = false;
                        }
                    }
                    break;
            }

            dungeon.Enemies.Remove(index);
            dungeon.Enemies.Add(enemy.X + enemy.Y * dungeon.Width, enemy);
        }

        public bool ExecuteAttack(Enemy enemy, Dungeon dungeon, Character character)
        {
            Queue<Tuple<int[], Tile>> tiles = new Queue<Tuple<int[], Tile>>();
            List<int> visitedTiles = new List<int>();
            tiles.Enqueue(new Tuple<int[], Tile>(new int[] { enemy.X, enemy.Y, 0 }, dungeon.GetTile(enemy.X, enemy.Y)));
            while (tiles.Count > 0)
            {
                var tuple = tiles.Dequeue();
                int x = tuple.Item1[0];
                int y = tuple.Item1[1];
                int currRange = tuple.Item1[2];
                visitedTiles.Add(x + y * dungeon.Width);
                if (tuple.Item2.IsPlayer)
                {
                    int damage = enemy.AttackUnit(character);
                    if (damage >= 0)
                    {
                        character.Draw(ConsoleColor.Red);
                        Thread.Sleep(50);
                        character.Draw();
                    }

                    return true;
                }

                if (currRange < enemy.Range)
                {
                    Tile upTile = dungeon.GetTile(x, Math.Max(y - 1, 0));
                    if ((upTile.IsFree || upTile.IsPlayer) && !visitedTiles.Contains(x + Math.Max(y - 1, 0) * dungeon.Width))
                    {
                        tiles.Enqueue(new Tuple<int[], Tile>(new int[] { x, Math.Max(y - 1, 0), currRange + 1 }, upTile));
                    }

                    Tile downTile = dungeon.GetTile(x, Math.Min(y + 1, dungeon.Height));
                    if ((downTile.IsFree || downTile.IsPlayer) && !visitedTiles.Contains(x + Math.Min(y + 1, dungeon.Height) * dungeon.Width))
                    {
                        tiles.Enqueue(new Tuple<int[], Tile>(new int[] { x, Math.Min(y + 1, dungeon.Height), currRange + 1 }, downTile));
                    }

                    Tile rightTile = dungeon.GetTile(Math.Min(x + 1, dungeon.Width), y);
                    if ((rightTile.IsFree || rightTile.IsPlayer) && !visitedTiles.Contains(Math.Min(x + 1, dungeon.Width) + y * dungeon.Width))
                    {
                        tiles.Enqueue(new Tuple<int[], Tile>(new int[] { Math.Min(x + 1, dungeon.Width), y, currRange + 1 }, rightTile));
                    }

                    Tile leftTile = dungeon.GetTile(Math.Max(x - 1, 0), y);
                    if ((leftTile.IsFree || leftTile.IsPlayer) && !visitedTiles.Contains(Math.Max(x - 1, 0) + y * dungeon.Width))
                    {
                        tiles.Enqueue(new Tuple<int[], Tile>(new int[] { Math.Max(x - 1, 0), y, currRange + 1 }, leftTile));
                    }
                }
            }

            return false;
        }
    }
}