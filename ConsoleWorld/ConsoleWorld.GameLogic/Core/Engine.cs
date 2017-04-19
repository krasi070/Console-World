using System.Collections.Generic;
using System.Linq;

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
        private int chp;
        private int ehp;
        private List<Enemy> eindex;
        
        public Engine()
        {
            this.screenHandler = new ScreenHandler();
            this.playerController = new PlayerController();
            this.enemyController = new EnemyController();
            this.dungeon = new Dungeon(DungeonX, DungeonY);
            this.statusHandler = new StatusHandler();
            this.messageHandler = new MessageHandler();
            this.eindex = new List<Enemy>();
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
                for(int i=0;i<dungeon.Enemies.Count;i++)
                {
                    this.playerController.EnemyInRange(character,dungeon, dungeon.Enemies[i]);
                    if (dungeon.Enemies[i].Hp <= 0)
                    {
                        dungeon.DrawTile(dungeon.Enemies[i].X, dungeon.Enemies[i].Y);
                        dungeon.GetTile(dungeon.Enemies[i].X, dungeon.Enemies[i].Y).IsEnemy = false;
                        eindex.Add(dungeon.Enemies[i]);
                    }
                    ehp = dungeon.Enemies[i].Hp;
                    Console.SetCursorPosition(96, 28);
                    Console.WriteLine(ehp);
                }

                foreach (var e in eindex)
                {
                    dungeon.Enemies.Remove(e);
                }
                chp = character.Hp;
                if (newDungeonFloor)
                {
                    this.CreateNewDungeon();
                    newDungeonFloor = false;
                    continue;
                }
                Console.SetCursorPosition(90,28);
                Console.WriteLine(chp);
                dungeon.MakeAdjacentTilesVisible(this.character.X, this.character.Y);
                foreach (var enemy in this.dungeon.Enemies)
                {
                    if (enemy.IsVisible)
                    {
                        this.enemyController.MoveEnemy(this.dungeon, enemy);
                        this.enemyController.PlayerInRange(enemy,dungeon,character);
                        
                    }
                }
                
            }
            Console.Clear();
            GameOver();
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

        private void GameOver()
        {
            GameOverScreen.Draw();
            GameOverScreen.BackToTitleScreen();
        }
    }
}