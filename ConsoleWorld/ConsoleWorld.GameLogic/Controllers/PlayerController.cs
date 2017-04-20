namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Data;
    using Enums;
    using Models;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Models.Enemies;
    using Handler;
    using Screens;

    public class PlayerController
    {
        private Random random = new Random();
        private MessageHandler messageHandler = new MessageHandler();

        public bool Action(ScreenHandler screenHandler,Dungeon dungeon, Character character, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    return MovePlayer(dungeon, character, key);
                case ConsoleKey.O:screenHandler.SelectOptionFromImproveStatsScreen(dungeon,character);
                    return true;
            }
            return false;
        }

        // returns true if status needs to be updated
        public bool MovePlayer(Dungeon dungeon, Character character, ConsoleKey key)
        {
            this.messageHandler.EraseMessage();
            Tile tile = new Tile(TileType.Unused);
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    tile = dungeon.GetTile(character.X, character.Y - 1);
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
                    else if (tile.Type == TileType.ClosedDoor)
                    {
                        if (Utility.CheckIfCharacterHasItem(character.Id, "Master Key"))
                        {
                            this.UnlockDoor(dungeon, character.X, character.Y - 1);
                        }
                        else if (Utility.CheckIfCharacterHasItem(character.Id, "Normal Key"))
                        {
                            this.UseItem(character.Id, "Normal Key");
                            this.UnlockDoor(dungeon, character.X, character.Y - 1);
                        }
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

                    else if (tile.Type == TileType.ClosedDoor)
                    {
                        if (Utility.CheckIfCharacterHasItem(character.Id, "Master Key"))
                        {
                            this.UnlockDoor(dungeon, character.X, character.Y + 1);
                        }
                        else if (Utility.CheckIfCharacterHasItem(character.Id, "Normal Key"))
                        {
                            this.UseItem(character.Id, "Normal Key");
                            this.UnlockDoor(dungeon, character.X, character.Y + 1);
                        }
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

                    else if (tile.Type == TileType.ClosedDoor)
                    {
                        if (Utility.CheckIfCharacterHasItem(character.Id, "Master Key"))
                        {
                            this.UnlockDoor(dungeon, character.X + 1, character.Y);
                        }
                        else if (Utility.CheckIfCharacterHasItem(character.Id, "Normal Key"))
                        {
                            this.UseItem(character.Id, "Normal Key");
                            this.UnlockDoor(dungeon, character.X + 1, character.Y);
                        }
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

                    else if (tile.Type == TileType.ClosedDoor)
                    {
                        if (Utility.CheckIfCharacterHasItem(character.Id, "Master Key"))
                        {
                            this.UnlockDoor(dungeon, character.X - 1, character.Y);
                        }
                        else if (Utility.CheckIfCharacterHasItem(character.Id, "Normal Key"))
                        {
                            this.UseItem(character.Id, "Normal Key");
                            this.UnlockDoor(dungeon, character.X - 1, character.Y);
                        }
                    }
                    break;
                
            }

            return this.CheckIfCharacterIsOnSpecialTile(dungeon, character, tile);
        }

        public void EnemyInRange(Character character, Dungeon dungeon, Enemy enemy)
        {
            for (int i = Math.Max(character.X - character.Range, 0); i <= Math.Min(character.X + character.Range, dungeon.Width); i++)
            {
                for (int j = Math.Max(character.Y - character.Range, 0); j <= Math.Min(character.Y + character.Range, dungeon.Height); j++)
                {
                    Tile tile = dungeon.GetTile(i, j);
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
                                                enemy.MagicDefense, 0);
                                    character.Mp--;
                                }
                                else
                                {
                                    enemy.Hp -= Math.Max((character.Attack + character.EquippedWeapon.Damage)
                                        - enemy.Defense, 0);
                                }
                            }
                            else
                            {
                                if (character.MagicAttack > character.Attack && character.Mp > 0)
                                {
                                    enemy.Hp -= Math.Max(character.MagicAttack - enemy.MagicDefense, 0);
                                    character.Mp--;
                                }
                                else
                                {
                                    enemy.Hp -= Math.Max(character.Attack - enemy.Defense, 0);
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

        private void UnlockDoor(Dungeon dungeon, int x, int y)
        {
            dungeon.SetTile(x, y, new Tile(TileType.OpenDoor));
            dungeon.DrawTile(x, y);
        }

        private void UseItem(int characterId, string itemName)
        {
            // TODO: add item effects
            Utility.RemoveOneItemFromCharacter(characterId, itemName);
        }

        private bool CheckIfCharacterIsOnSpecialTile(Dungeon dungeon, Character character, Tile tile)
        {
            switch (tile.Type)
            {
                case TileType.UpStairs:
                    break;
                case TileType.DownStairs:
                    break;
                case TileType.MagicWell:
                    break;
                case TileType.Money:
                    this.PickUpMoney(dungeon, character);
                    return true;
                case TileType.Item:
                    this.PickUpItem(dungeon, character);
                    return true;
            }

            return false;
        }

        private void PickUpMoney(Dungeon dungeon, Character character)
        {
            int amount = random.Next(1, 11);
            character.Money += random.Next(1, 11);
            dungeon.SetTile(character.X, character.Y, new Tile(TileType.Floor));
            this.messageHandler.MoneyMessage(character, amount);
        }

        private void PickUpItem(Dungeon dungeon, Character character)
        {
            Utility.AddItemToCharacter(character.Id, dungeon.Items[character.X + character.Y * dungeon.Width].Id);
            this.messageHandler.ItemMessage(character, dungeon.Items[character.X + character.Y * dungeon.Width]);
            dungeon.Items.Remove(character.X + character.Y * dungeon.Width);
            dungeon.SetTile(character.X, character.Y, new Tile(TileType.Floor));
        }
    }
}