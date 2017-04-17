namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Models;
    using System;

    public class PlayerController
    {
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
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y--;
                        character.Draw();
                        tile.IsFree = false;
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
                    break;
            }
        }
    }
}