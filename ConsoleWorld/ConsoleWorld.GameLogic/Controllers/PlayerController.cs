namespace ConsoleWorld.GameLogic.Controllers
{
    using Core;
    using Enums;
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
                    if (dungeon.GetTile(character.X, character.Y - 1).Type != TileType.Wall)
                    {
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y--;
                        character.Draw();
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (dungeon.GetTile(character.X, character.Y + 1).Type != TileType.Wall)
                    {
                        dungeon.DrawTile(character.X, character.Y);
                        character.Y++;
                        character.Draw();
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (dungeon.GetTile(character.X + 1, character.Y).Type != TileType.Wall)
                    {
                        dungeon.DrawTile(character.X, character.Y);
                        character.X++;
                        character.Draw();
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (dungeon.GetTile(character.X - 1, character.Y).Type != TileType.Wall)
                    {
                        dungeon.DrawTile(character.X, character.Y);
                        character.X--;
                        character.Draw();
                    }
                    break;
            }
        }
    }
}