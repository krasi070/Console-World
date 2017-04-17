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
            //TitleScreen.Draw();
            //this.screenHandler.SelectOptionFromTitleScreen();
            this.dungeon.Generate(dungeonLevel + dungeonSize);
            // This character is only for testing purposes
            Character character = new Archer();
            character.Name = "Archer";
            this.dungeon.PlacePlayer(character);
            var rat = new Rat();
            this.dungeon.PlaceEnemy(rat);
            this.statusHandler.Draw(character, dungeonLevel);
            this.messageHandler.BattleMessage(character, rat, 20);
            ConsoleKey key = Console.ReadKey(true).Key;
            while (true)
            {
                this.playerController.MovePlayer(dungeon, character, key);
                dungeon.MakeAdjacentTilesVisible(character.X, character.Y);
                if (rat.IsVisible)
                {
                    this.enemyController.MoveEnemy(this.dungeon, rat);
                }

                key = Console.ReadKey(true).Key;
            }
        }
    }
}