using System.Diagnostics;
using System.Threading;
using ConsoleWorld.Models;

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
                    if (tile.IsFree && !tile.IsPlayer)
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
                    if (tile.IsFree && !tile.IsPlayer)
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
                    if (tile.IsFree && !tile.IsPlayer)
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
                    if (tile.IsFree && !tile.IsPlayer)
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
        public void PlayerInRange(Enemy enemy, Dungeon dungeon,Character character)
        {
            for (int i = Math.Max(enemy.X - enemy.Range, 0); i <= Math.Min(enemy.X + enemy.Range, dungeon.Width); i++)
            {
                for (int j = Math.Max(enemy.Y - enemy.Range, 0); j <= Math.Min(enemy.Y + enemy.Range, dungeon.Height); j++)
                {
                    Tile tile = dungeon.GetTile(i, j);
                    if (tile.IsPlayer)
                    {
                        if (random.Next(100) < character.Evade && random.Next(100) < enemy.Accuracy)
                        {
                            if (enemy.EquippedWeapon != null)
                            {
                                if (enemy.MagicAttack + enemy.EquippedWeapon.MagicPower >
                                    enemy.Attack + enemy.EquippedWeapon.Damage && enemy.Mp > 0)
                                {
                                    character.Hp -= Math.Max((enemy.MagicAttack + enemy.EquippedWeapon.MagicPower) -
                                                             character.MagicDefense, 0);
                                    enemy.Mp--;
                                }
                                else
                                {
                                    character.Hp -= Math.Max((enemy.Attack + enemy.EquippedWeapon.Damage)
                                                             - character.Defense, 0);
                                }
                            }
                            else
                            {
                                if (enemy.MagicAttack > enemy.Attack && enemy.Mp > 0)
                                {
                                    character.Hp -= Math.Max(enemy.MagicAttack - character.MagicDefense, 0);
                                    enemy.Mp--;
                                }
                                else
                                {
                                    character.Hp -= Math.Max(enemy.Attack - character.Defense, 0);
                                }
                            }

                            Console.SetCursorPosition(i, j);
                            enemy.Draw(ConsoleColor.Red);
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            Thread.Sleep(50);
                            stopWatch.Stop();
                            Console.SetCursorPosition(i, j);
                            enemy.Draw();
                        }
                    }
                }
            }
            
        }
    }
}