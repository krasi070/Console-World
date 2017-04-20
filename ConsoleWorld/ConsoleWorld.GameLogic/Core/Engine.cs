namespace ConsoleWorld.GameLogic.Core
{
    using Controllers;
    using Handler;
    using Models;
    using Models.Enemies;
    using Screens;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const int DungeonX = 120;
        private const int DungeonY = 24;
        private const int DungeonSize = 4;

        private ScreenHandler screenHandler;
        private PlayerController playerController;
        private EnemyController enemyController;
        private Dungeon dungeon;
        private StatusHandler statusHandler;
        private MessageHandler messageHandler;
        private Character character;
        private int dungeonLevel = 0;
        private List<int> eindex;
        
        public Engine()
        {
            this.screenHandler = new ScreenHandler();
            this.playerController = new PlayerController();
            this.enemyController = new EnemyController();
            this.statusHandler = new StatusHandler();
            this.messageHandler = new MessageHandler();
            this.eindex = new List<int>();
        }

        public void Run()
        {
            TitleScreen.Draw();
            while (true)
            {
                if (this.screenHandler.SelectOptionFromTitleScreen())
                {
                    this.character = this.screenHandler.SelectOptionFromStartMenuScreen();
                    if (this.character != null)
                    {
                        Console.Clear();
                        
                        this.GameLoop();
                    }
                }
            }
        }

        private void GameLoop()
        {
            bool newDungeonFloor = false;
            this.CreateNewDungeon();
            
            //this.messageHandler.BattleMessage(this.character, rat, 20);
            while (this.character.IsAlive)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (this.playerController.Action(screenHandler, dungeon, this.character, key))
                {
                    this.statusHandler.Draw(this.character, dungeonLevel);
                }

                foreach (var enemy in this.dungeon.Enemies.Values) 
                {
                    if (enemy.Hp <= 0)
                    {
                        dungeon.DrawTile(enemy.X, enemy.Y);
                        dungeon.GetTile(enemy.X, enemy.Y).IsEnemy = false;
                        eindex.Add(enemy.X + enemy.Y * dungeon.Width);
                        this.messageHandler.KillMessage(this.character, enemy);
                    }
                }

                foreach (var e in eindex)
                {
                    dungeon.Enemies.Remove(e);
                }

                if (newDungeonFloor)
                {
                    this.CreateNewDungeon();
                    newDungeonFloor = false;
                    continue;
                }

                dungeon.MakeAdjacentTilesVisible(this.character.X, this.character.Y);
                if (this.IsInputValid(key))
                {
                    var enemies = this.dungeon.Enemies.Values.ToList();
                    foreach (var enemy in enemies)
                    {
                        if (enemy.IsVisible)
                        {
                            if (this.enemyController.Action(this.dungeon, enemy, this.character))
                            {
                                this.statusHandler.Draw(this.character, dungeonLevel);
                            }
                        }
                    }
                }
            }

            Console.Clear();
            GameOver();
        }

        private bool IsInputValid(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.W:
                case ConsoleKey.S:
                case ConsoleKey.A:
                case ConsoleKey.D:
                case ConsoleKey.K:
                    return true;
                default:
                    return false;
            }
        }

        private void CreateNewDungeon()
        {
            Console.Clear();
            this.dungeonLevel++;
            this.dungeon = new Dungeon(DungeonX, DungeonY);
            this.dungeon.Generate(dungeonLevel + DungeonSize);
            while (this.dungeon.Rooms.Count == 0)
            {
                this.dungeon = new Dungeon(DungeonX, DungeonY);
                this.dungeon.Generate(dungeonLevel + DungeonSize);
            }

            this.dungeon.PlacePlayer(this.character);
            // this rat is for testing
            var rat = new Rat();
            this.dungeon.PlaceEnemy(rat);
            this.statusHandler.Draw(this.character, dungeonLevel);
        }

        private void GameOver()
        {
            GameOverScreen.Draw();
            GameOverScreen.BackToTitleScreen();
        }
    }
}