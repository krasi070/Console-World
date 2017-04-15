namespace ConsoleWorld.GameLogic.Core
{
    using Controllers;
    using Models;
    using Screens;
    using System;

    public class Engine
    {
        private const int DungeonX = 120;
        private const int DungeonY = 28;

        private ScreenHandler screenHandler;
        private PlayerController playerController;
        private Dungeon dungeon;

        public Engine()
        {
            this.screenHandler = new ScreenHandler();
            this.playerController = new PlayerController();
            this.dungeon = new Dungeon(DungeonX, DungeonY);
        }

        public void Run()
        {
            //TitleScreen.Draw();
            //this.screenHandler.SelectOptionFromTitleScreen();
            this.dungeon.Generate(10);
            this.dungeon.Draw();
            // This character is only for testing purposes
            Character character = new Character();
            this.dungeon.PlacePlayer(character);
            ConsoleKey key = Console.ReadKey(true).Key;
            while (true)
            {
                this.playerController.MovePlayer(dungeon, character, key);

                key = Console.ReadKey(true).Key;
            }
        }
    }
}