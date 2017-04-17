namespace ConsoleWorld.GameLogic.Core
{
    using Enums;
    using Geometry;
    using Models;
    using System;
    using System.Collections.Generic;

    public class Dungeon
    {
        private const int RoomChance = 50;
        private const int MinRoomSize = 5;
        private const int MaxRoomSize = 8;
        private const int MinCorridorLength = 5;
        private const int MaxCorridorLength = 8;
        private const int VisibilityRange = 1;

        private Random random;

        public Dungeon(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Tiles = new List<Tile>();
            this.FillTiles();
            this.Rooms = new List<Rectangle>();
            this.Exits = new List<Rectangle>();
            this.random = new Random();
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public List<Tile> Tiles { get; set; }

        private List<Rectangle> Rooms { get; set; }

        private List<Rectangle> Exits { get; set; }

        public void Generate(int maxFeatures)
        {
            // place the first room in the center
            if (!this.CreateRoom(this.Width / 2, this.Height / 2, (Direction)random.Next(4), true))
            {
                Console.WriteLine("Unable to place the first room.");

                return;
            }

            // we already placed 1 feature (the first room)
            for (int i = 1; i < maxFeatures; i++)
            {
                if (!this.CreateFeature())
                {
                    Console.WriteLine($"Unable to place more features (placed {i})");
                    break;
                }
            }

            if (!this.PlaceObject(TileType.UpStairs))
            {
                Console.WriteLine("Unable to place up stairs.");

                return;
            }

            if (!this.PlaceObject(TileType.DownStairs))
            {
                Console.WriteLine("Unable to place down stairs.");

                return;
            }
        }

        public void Draw()
        {
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.DrawTile(x, y);
                }
            }
        }

        public void DrawTile(int x, int y)
        {
            Tile tile = this.GetTile(x, y);
            if (tile.IsVisibe)
            {
                Console.SetCursorPosition(x, y);
                if (tile.IsDefaultColors)
                {
                    Console.Write(tile.Symbol);
                }
                else
                {
                    Console.ForegroundColor = tile.ForegroundColor;
                    Console.BackgroundColor = tile.BackgroundColor;
                    Console.Write(tile.Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.Width || y >= this.Height)
            {
                return new Tile(TileType.Unused);
            }

            return this.Tiles[x + y * this.Width];
        }

        public bool PlacePlayer(Character character)
        {
            if (this.Rooms.Count == 0)
            {
                return false;
            }

            int index = random.Next(this.Rooms.Count);
            int x = random.Next(this.Rooms[index].X + 1, this.Rooms[index].X + this.Rooms[index].Width - 2);
            int y = random.Next(this.Rooms[index].Y + 1, this.Rooms[index].Y + this.Rooms[index].Height - 2);

            if (this.GetTile(x, y).Type == TileType.Floor)
            {
                character.X = x;
                character.Y = y;
                character.Draw();
                this.MakeAdjacentTilesVisible(character.X, character.Y);

                // place one object in one room (optional)
                this.Rooms.RemoveAt(index);

                return true;
            }

            return false;
        }

        public void MakeAdjacentTilesVisible(int x, int y)
        {
            for (int i = Math.Max(x - VisibilityRange, 0); i <= Math.Min(x + VisibilityRange, this.Width); i++)
            {
                for (int j = Math.Max(y - VisibilityRange, 0); j <= Math.Min(y + VisibilityRange, this.Height); j++)
                {
                    this.GetTile(i, j).IsVisibe = true;

                    if (i != x || j != y)
                    {
                        this.DrawTile(i, j);
                    }
                }
            }
        }

        private void SetTile(int x, int y, Tile tile)
        {
            this.Tiles[x + y * this.Width] = tile;
        }

        private bool CreateFeature()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (this.Exits.Count == 0)
                {
                    break;
                }

                // choose a random side of a random room or corridor
                int index = random.Next(this.Exits.Count);
                int x = random.Next(this.Exits[index].X, this.Exits[index].X + this.Exits[index].Width - 1);
                int y = random.Next(this.Exits[index].Y, this.Exits[index].Y + this.Exits[index].Height - 1);

                // north, south, west, east
                for (int j = 0; j < Enum.GetValues(typeof(Direction)).Length; j++)
                {
                    if (this.CreateFeauture(x, y, (Direction)j))
                    {
                        this.Exits.RemoveAt(index);

                        return true;
                    }
                }
            }

            return false;
        }

        private bool CreateFeauture(int x, int y, Direction direction)
        {
            int dX = 0;
            int dY = 0;

            if (direction == Direction.North)
            {
                dY = 1;
            }
            else if (direction == Direction.South)
            {
                dY = -1;
            }
            else if (direction == Direction.West)
            {
                dX = 1;
            }
            else if (direction == Direction.East)
            {
                dX = -1;
            }

            if (this.GetTile(x + dX, y + dY).Type != TileType.Floor && this.GetTile(x + dX, y + dY).Type != TileType.Corridor)
            {
                return false;
            }

            if (random.Next(100) < RoomChance)
            {
                if (this.CreateRoom(x, y, direction))
                {
                    this.SetTile(x, y, new Tile(TileType.ClosedDoor));

                    return true;
                }
            }
            else
            {
                if (this.CreateCorridor(x, y, direction))
                {
                    if (this.GetTile(x + dX, y + dY).Type == TileType.Floor)
                    {
                        this.SetTile(x, y, new Tile(TileType.ClosedDoor));
                    }
                    else
                    {
                        this.SetTile(x, y, new Tile(TileType.Corridor));
                    }
                }
            }

            return false;
        }

        private bool CreateRoom(int x, int y, Direction direction, bool isFirstRoom = false)
        {
            Rectangle room = new Rectangle();
            room.Width = random.Next(MinRoomSize, MaxRoomSize);
            room.Height = random.Next(MinRoomSize, MaxRoomSize);

            if (direction == Direction.North)
            {
                room.X = x - room.Width / 2;
                room.Y = y - room.Height;
            }
            else if (direction == Direction.South)
            {
                room.X = x - room.Width / 2;
                room.Y = y + 1;
            }
            else if (direction == Direction.West)
            {
                room.X = x - room.Width;
                room.Y = y - room.Height / 2;
            }
            else if (direction == Direction.East)
            {
                room.X = x + 1;
                room.Y = y - room.Height / 2;
            }

            if (this.PlaceRectangle(room, TileType.Floor))
            {
                this.Rooms.Add(room);
                if (direction != Direction.South || isFirstRoom)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = room.X,
                        Y = room.Y - 1,
                        Width = room.Width,
                        Height = 1
                    });
                }

                if (direction != Direction.North || isFirstRoom)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = room.X,
                        Y = room.Y + room.Height,
                        Width = room.Width,
                        Height = 1
                    });
                }

                if (direction != Direction.East || isFirstRoom)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = room.X - 1,
                        Y = room.Y,
                        Width = 1,
                        Height = room.Height
                    });
                }

                if (direction != Direction.West || isFirstRoom)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = room.X + room.Width,
                        Y = room.Y,
                        Width = 1,
                        Height = room.Height
                    });
                }

                return true;
            }

            return false;
        }

        private bool CreateCorridor(int x, int y, Direction direction)
        {
            Rectangle corridor = new Rectangle();
            corridor.X = x;
            corridor.Y = y;

            // horizontal corridor 
            if (random.Next(2) == 0)
            {
                corridor.Width = random.Next(MinCorridorLength, MaxCorridorLength);
                corridor.Height = 1;

                if (direction == Direction.North)
                {
                    corridor.Y = y - 1;
                    if (random.Next(2) == 0) // west
                    {
                        corridor.X = x - corridor.Width + 1;
                    }
                }
                else if (direction == Direction.South)
                {
                    corridor.Y = y + 1;
                    if (random.Next(2) == 0) // west
                    {
                        corridor.X = x - corridor.Width + 1;
                    }
                }
                else if (direction == Direction.West)
                {
                    corridor.X = x - corridor.Width;
                }
                else if (direction == Direction.East)
                {
                    corridor.X = x + 1;
                }
            }
            else // vertical corridor
            {
                corridor.Width = 1;
                corridor.Height = random.Next(MinCorridorLength, MaxCorridorLength);

                if (direction == Direction.North)
                {
                    corridor.Y = y - corridor.Height;
                }
                else if (direction == Direction.South)
                {
                    corridor.Y = y + 1;
                }
                else if (direction == Direction.West)
                {
                    corridor.X = x - 1;
                    if (random.Next(2) == 0) // north
                    {
                        corridor.Y = y - corridor.Height + 1;
                    }
                }
                else if (direction == Direction.East)
                {
                    corridor.X = x + 1;
                    if (random.Next(2) == 0)
                    {
                        corridor.Y = y - corridor.Height + 1;
                    }
                }
            }

            if (this.PlaceRectangle(corridor, TileType.Corridor))
            {
                if (direction != Direction.South && corridor.Width != 1)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = corridor.X,
                        Y = corridor.Y - 1,
                        Width = corridor.Width,
                        Height = 1
                    });
                }

                if (direction != Direction.North && corridor.Width != 1)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = corridor.X,
                        Y = corridor.Y + corridor.Height,
                        Width = corridor.Width,
                        Height = 1
                    });
                }

                if (direction != Direction.East && corridor.Height != 1)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = corridor.X - 1,
                        Y = corridor.Y,
                        Width = 1,
                        Height = corridor.Height
                    });
                }

                if (direction != Direction.West && corridor.Height != 1)
                {
                    this.Exits.Add(new Rectangle()
                    {
                        X = corridor.X + corridor.Width,
                        Y = corridor.Y,
                        Width = 1,
                        Height = corridor.Height
                    });
                }

                return true;
            }

            return false;
        }

        private bool PlaceRectangle(Rectangle rectangle, TileType tile)
        {
            if (rectangle.X < 1 ||
                rectangle.Y < 1 ||
                rectangle.X + rectangle.Width > this.Width - 1 ||
                rectangle.Y + rectangle.Height > this.Height - 1)
            {
                return false;
            }

            for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; y++)
            {
                for (int x = rectangle.X; x < rectangle.X + rectangle.Width; x++)
                {
                    if (this.GetTile(x, y).Type != TileType.Unused)
                    {
                        return false; // the area is already used
                    }
                }
            }

            for (int y = rectangle.Y - 1; y < rectangle.Y + rectangle.Height + 1; y++)
            {
                for (int x = rectangle.X - 1; x < rectangle.X + rectangle.Width + 1; x++)
                {
                    if (x == rectangle.X - 1 ||
                        y == rectangle.Y - 1 ||
                        x == rectangle.X + rectangle.Width ||
                        y == rectangle.Y + rectangle.Height)
                    {
                        this.SetTile(x, y, new Tile(TileType.Wall));
                    }
                    else
                    {
                        this.SetTile(x, y, new Tile(tile));
                    }
                }
            }

            return true;
        }

        private bool PlaceObject(TileType tile)
        {
            if (this.Rooms.Count == 0)
            {
                return false;
            }

            int index = random.Next(this.Rooms.Count);
            int x = random.Next(this.Rooms[index].X + 1, this.Rooms[index].X + this.Rooms[index].Width - 2);
            int y = random.Next(this.Rooms[index].Y + 1, this.Rooms[index].Y + this.Rooms[index].Height - 2);

            if (this.GetTile(x, y).Type == TileType.Floor)
            {
                this.SetTile(x, y, new Tile(tile));

                // place one object in one room (optional)
                this.Rooms.RemoveAt(index);

                return true;
            }

            return false;
        }

        private void FillTiles()
        {
            for (int i = 0; i < this.Width * this.Height; i++)
            {
                this.Tiles.Add(new Tile(TileType.Unused));
            }
        }
    }
}
