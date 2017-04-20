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
                        this.character.Money = 100;
                        this.dungeonLevel = character.DungeonLevel - 1;
                        Console.Clear();
                        
                        this.GameLoop();
                    }

                    dungeonLevel = 0;
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

                // 0 - nothing
                // 1 - update status
                // 2 - next dungeon
                int code = this.playerController.Action(screenHandler, dungeon, this.character, key);
                if (code == 1)
                {
                    this.statusHandler.Draw(this.character, dungeonLevel);
                }
                else if (code == 2)
                {
                    newDungeonFloor = true;
                }

                foreach (var enemyPair in this.dungeon.Enemies) 
                {
                    if (!enemyPair.Value.IsAlive)
                    {
                        dungeon.DrawTile(enemyPair.Value.X, enemyPair.Value.Y);
                        dungeon.GetTile(enemyPair.Value.X, enemyPair.Value.Y).IsEnemy = false;
                        dungeon.GetTile(enemyPair.Value.X, enemyPair.Value.Y).IsFree = true;
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
            Utility.DeleteCharacter(this.character.Id);
            GameOver();
        }

        private void GiveEnemyRewards(Enemy enemy)
        {
            this.character.Money += enemy.Money;
            this.character.Exp += enemy.ExpReward;
            while (this.character.Exp >= Utility.GetExpToNextLevel(this.character.Id))
            {
                int additionalExp = this.character.Exp - Utility.GetExpToNextLevel(this.character.Id);
                this.character.LevelId++;
                this.character.Exp = additionalExp;
                this.character.Points = Utility.GetPointsToReceive(this.character.Id);
                Utility.SaveCharacter(this.character);
            }

            Utility.SaveCharacter(this.character);
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
            this.character.DungeonLevel++;
            Utility.SaveCharacter(this.character);
            this.dungeon = new Dungeon(DungeonX, DungeonY);
            this.dungeon.Generate(dungeonLevel + DungeonSize, dungeonLevel);
            while (this.dungeon.Rooms.Count == 0)
            {
                this.dungeon = new Dungeon(DungeonX, DungeonY);
                this.dungeon.Generate(dungeonLevel + DungeonSize, dungeonLevel);
            }

            this.dungeon.PlacePlayer(this.character);
            this.statusHandler.Draw(this.character, dungeonLevel);
        }

        private void GameOver()
        {
            GameOverScreen.Draw();
            GameOverScreen.BackToTitleScreen();
        }
    }
}