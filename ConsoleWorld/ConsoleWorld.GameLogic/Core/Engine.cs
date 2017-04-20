namespace ConsoleWorld.GameLogic.Core
{
    using Controllers;
    using Data;
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
                        this.character.Money = 10;
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

                foreach (var enemyPair in this.dungeon.Enemies) 
                {
                    if (enemyPair.Value.Hp <= 0)
                    {
                        dungeon.DrawTile(enemyPair.Value.X, enemyPair.Value.Y);
                        dungeon.GetTile(enemyPair.Value.X, enemyPair.Value.Y).IsEnemy = false;
                        eindex.Add(enemyPair.Key);
                        this.messageHandler.KillMessage(this.character, enemyPair.Value);
                        this.GiveEnemyRewards(enemyPair.Value);
                    }
                }

                foreach (var e in eindex)
                {
                    var tile = dungeon.GetTile(dungeon.Enemies[e].X, dungeon.Enemies[e].Y);
                    tile.IsFree = true;
                    tile.IsEnemy = false;
                    dungeon.DrawTile(dungeon.Enemies[e].X, dungeon.Enemies[e].Y);
                    dungeon.Enemies.Remove(e);
                }

                eindex.Clear();
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

        private void GiveEnemyRewards(Enemy enemy)
        {
            this.character.Exp += enemy.ExpReward;
            int x = this.character.X;
            int y = this.character.Y;
            while (this.character.Exp >= Utility.GetExpToNextLevel(this.character.Id))
            {
                int additionalExp = this.character.Exp - Utility.GetExpToNextLevel(this.character.Id);
                Utility.IncreaseCharacterLevel(character.Id, additionalExp);
                this.character = Utility.GetCharacterByName(character.Name);
                this.character.X = x;
                this.character.Y = y;
            }

            this.statusHandler.Draw(character, dungeonLevel);
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