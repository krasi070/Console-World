namespace ConsoleWorld.GameLogic.Core
{
    using Controllers;
    using Handler;
    using Models;
    using Models.Classes;
    using Models.Enemies;
    using Screens;
    using System;

    public class Engine
    {
        private const int DungeonX = 120;
        private const int DungeonY = 24;

        private ScreenHandler screenHandler;
        private PlayerController playerController;
        private EnemyController enemyController;
        private Dungeon dungeon;
        private StatusHandler statusHandler;
        private MessageHandler messageHandler;

        private Character character;
        private int dungeonLevel = 1;
        private int dungeonSize = 4;

        public Engine()
        {
            this.screenHandler = new ScreenHandler();
            this.playerController = new PlayerController();
            this.enemyController = new EnemyController();
            this.dungeon = new Dungeon(DungeonX, DungeonY);
            this.statusHandler = new StatusHandler();
            this.messageHandler = new MessageHandler();
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
                this.playerController.MovePlayer(dungeon, this.character, key);
                if (newDungeonFloor)
                {
                    this.CreateNewDungeon();
                    newDungeonFloor = false;
                    continue;
                }

                dungeon.MakeAdjacentTilesVisible(this.character.X, this.character.Y);
                foreach (var enemy in this.dungeon.Enemies)
                {
                    if (enemy.IsVisible)
                    {
                        this.enemyController.MoveEnemy(this.dungeon, enemy);
                    }
                }
            }
        }

        private void CreateNewDungeon()
        {
            Console.Clear();
            this.dungeonLevel++;
            this.dungeon.Generate(dungeonLevel + dungeonSize);
            this.dungeon.PlacePlayer(this.character);
            // this rat is for testing
            var rat = new Rat();
            this.dungeon.PlaceEnemy(rat);
            this.statusHandler.Draw(this.character, dungeonLevel);
        }
    }
}