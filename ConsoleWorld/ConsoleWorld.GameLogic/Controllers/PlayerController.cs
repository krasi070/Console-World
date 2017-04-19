namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Data;
    using Enums;
    using Models;
    using System;

    public class PlayerController
    {
        private Random random = new Random();

        // returns true if status needs to be updated
        public bool MovePlayer(Dungeon dungeon, Character character, ConsoleKey key)
        {
            Tile tile = null;
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    tile = dungeon.GetTile(character.X, character.Y - 1);
                    if (tile.IsFree && !tile.IsEnemy)
                    {
                        dungeon.GetTile(character.X, character.Y).IsFree = true;
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y--;
                        character.Draw();
                        tile.IsFree = false;
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
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y++;
                        character.Draw();
                        tile.IsFree = false;
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
                        dungeon.DrawTile(character.X, character.Y);
                        character.X++;
                        character.Draw();
                        tile.IsFree = false;
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
                        dungeon.DrawTile(character.X, character.Y);
                        character.X--;
                        character.Draw();
                        tile.IsFree = false;
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
                    character.Money += random.Next(1, 11);
                    dungeon.SetTile(character.X, character.Y, new Tile(TileType.Floor));
                    return true;
                case TileType.Item:
                    break;
            }

            return false;
        }
    }
}