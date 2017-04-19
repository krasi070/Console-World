using System.Diagnostics;
using System.Threading;
using ConsoleWorld.Models.Enemies;

namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Models;
    using System;

    public class PlayerController
    {
        private Random random=new Random();
        public void MovePlayer(Dungeon dungeon, Character character, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Tile tile = dungeon.GetTile(character.X, character.Y - 1);
                    if (tile.IsFree && !tile.IsEnemy)
                    {
                        dungeon.GetTile(character.X, character.Y).IsFree = true;
                        dungeon.GetTile(character.X, character.Y).IsPlayer = false;
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y--;
                        character.Draw();
                        tile.IsFree = false;
                        tile.IsPlayer = true;
                    }
                    
                    
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    tile = dungeon.GetTile(character.X, character.Y + 1);
                    if (tile.IsFree && !tile.IsEnemy)
                    {
                        dungeon.GetTile(character.X, character.Y).IsFree = true;
                        dungeon.GetTile(character.X, character.Y).IsPlayer = false;
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y++;
                        character.Draw();
                        tile.IsFree = false;
                        tile.IsPlayer = true;
                    }
                   
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    tile = dungeon.GetTile(character.X + 1, character.Y);
                    if (tile.IsFree && !tile.IsEnemy)
                    {
                        dungeon.GetTile(character.X, character.Y).IsFree = true;
                        dungeon.GetTile(character.X, character.Y).IsPlayer = false;
                        dungeon.DrawTile(character.X, character.Y);
                        character.X++;
                        character.Draw();
                        tile.IsFree = false;
                        tile.IsPlayer = true;
                    }
                    
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    tile = dungeon.GetTile(character.X - 1, character.Y);
                    if (tile.IsFree && !tile.IsEnemy)
                    {
                        dungeon.GetTile(character.X, character.Y).IsFree = true;
                        dungeon.GetTile(character.X, character.Y).IsPlayer = false;
                        dungeon.DrawTile(character.X, character.Y);
                        character.X--;
                        character.Draw();
                        tile.IsFree = false;
                        tile.IsPlayer = true;
                    }

                    
                    break;
            }
        }

        public void EnemyInRange(Character character,Dungeon dungeon,Enemy enemy)
        {
            for (int i = Math.Max(character.X-character.Range, 0); i <= Math.Min(character.X + character.Range, dungeon.Width); i++)
            {
                for (int j = Math.Max(character.Y - character.Range, 0); j <= Math.Min(character.Y + character.Range, dungeon.Height); j++)
                {
                    Tile tile = dungeon.GetTile(i,j);
                    if (tile.IsEnemy)
                    {
                        if (random.Next(100) > enemy.Evade && random.Next(100) < character.Accuracy)
                        {
                            if (character.EquippedWeapon != null)
                            {
                                if (character.MagicAttack + character.EquippedWeapon.MagicPower >
                                    character.Attack + character.EquippedWeapon.Damage && character.Mp > 0)
                                {
                                    enemy.Hp -= Math.Max((character.MagicAttack + character.EquippedWeapon.MagicPower) -
                                                enemy.MagicDefense,0);
                                    character.Mp--;
                                }
                                else
                                {
                                    enemy.Hp -= Math.Max((character.Attack + character.EquippedWeapon.Damage) 
                                        - enemy.Defense,0);
                                }
                            }
                            else
                            {
                                if(character.MagicAttack  > character.Attack && character.Mp > 0)
                                {
                                    enemy.Hp -= Math.Max(character.MagicAttack - enemy.MagicDefense,0);
                                    character.Mp--;
                                }
                                else
                                {
                                    enemy.Hp -= Math.Max(character.Attack  - enemy.Defense,0);
                                }
                            }
                            Console.SetCursorPosition(i, j);
                            character.Draw(ConsoleColor.Red);
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            Thread.Sleep(50);
                            stopWatch.Stop();
                            Console.SetCursorPosition(i, j);
                            character.Draw();
                        }
                    }
                }
            }
           
        }
        
    }
}