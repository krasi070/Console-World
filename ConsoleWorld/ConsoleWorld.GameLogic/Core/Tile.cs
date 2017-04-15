namespace ConsoleWorld.GameLogic.Core
{
    using Enums;
    using System;

    public class Tile
    {
        public Tile(TileType type)
        {
            this.Type = type;
            this.SetColorsForType();
            this.SetSymbolForType();
        }

        public char Symbol { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public bool IsDefaultColors { get; set; }

        public TileType Type { get; set; }

        private void SetColorsForType()
        {
            switch (this.Type)
            {
                case TileType.Unused:
                case TileType.Floor:
                case TileType.Corridor:
                case TileType.UpStairs:
                case TileType.DownStairs:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.White;
                    this.IsDefaultColors = true;
                    break;
                case TileType.Wall:
                    this.BackgroundColor = ConsoleColor.Gray;
                    this.ForegroundColor = ConsoleColor.Gray;
                    this.IsDefaultColors = false;
                    break;
                case TileType.ClosedDoor:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.Yellow;
                    this.IsDefaultColors = false;
                    break;
                case TileType.OpenDoor:
                    this.BackgroundColor = ConsoleColor.Yellow;
                    this.ForegroundColor = ConsoleColor.Black;
                    this.IsDefaultColors = false;
                    break;
            }
        }

        private void SetSymbolForType()
        {
            switch (this.Type)
            {
                case TileType.Unused:
                case TileType.Wall:
                case TileType.OpenDoor:
                    this.Symbol = ' ';
                    break;
                case TileType.Floor:
                case TileType.Corridor:
                    this.Symbol = '.';
                    break;
                case TileType.ClosedDoor:
                    this.Symbol = '+';
                    break;
                case TileType.UpStairs:
                    this.Symbol = '<';
                    break;
                case TileType.DownStairs:
                    this.Symbol = '>';
                    break;
            }
        }
    }
}