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
            this.SetValueForIsFree();
            this.IsVisibe = false;
            this.IsEnemy = false;
            this.IsPlayer = false;
        }

        public char Symbol { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public TileType Type { get; set; }

        public bool IsVisibe { get; set; }

        public bool IsFree { get; set; }

        public bool IsEnemy { get; set; }

        public bool IsPlayer { get; set; }

        private void SetColorsForType()
        {
            switch (this.Type)
            {
                case TileType.Unused:
                case TileType.Floor:
                case TileType.Corridor:
                case TileType.Hole:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.White;
                    break;
                case TileType.Wall:
                    this.BackgroundColor = ConsoleColor.Gray;
                    this.ForegroundColor = ConsoleColor.Gray;
                    break;
                case TileType.ClosedDoor:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TileType.OpenDoor:
                    this.BackgroundColor = ConsoleColor.Yellow;
                    this.ForegroundColor = ConsoleColor.Black;
                    break;
                case TileType.Item:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TileType.Money:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.Green;
                    break;
                case TileType.MagicWell:
                    this.BackgroundColor = ConsoleColor.Black;
                    this.ForegroundColor = ConsoleColor.Blue;
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
                case TileType.Hole:
                    this.Symbol = 'o';
                    break;
                case TileType.Item:
                    this.Symbol = '%';
                    break;
                case TileType.Money:
                    this.Symbol = '$';
                    break;
                case TileType.MagicWell:
                    this.Symbol = '=';
                    break;
            }
        }

        private void SetValueForIsFree()
        {
            switch (this.Type)
            {
                case TileType.Unused:
                case TileType.Wall:
                case TileType.ClosedDoor:
                    this.IsFree = false;
                    break;
                case TileType.Floor:
                case TileType.Corridor:
                case TileType.OpenDoor:
                case TileType.Hole:
                case TileType.Item:
                case TileType.Money:
                case TileType.MagicWell:
                    this.IsFree = true;
                    break;
            }
        }
    }
}