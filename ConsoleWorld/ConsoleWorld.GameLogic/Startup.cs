﻿namespace ConsoleWorld.GameLogic
{
    using System;
    using Core;
    using Screens;

    public class Startup
    {
        public static void Main()
        {
            SetConsoleValues();
            Engine engine = new Engine();
            engine.Run();
            //ItemsScreen.ListItems();
            //ItemsScreen.SelectOption();
            //TitleScreen.Draw();
        }

        private static void SetConsoleValues()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            //Console.BufferWidth = Console.WindowWidth;
            //Console.BufferHeight = Console.WindowHeight;
        }
    }
}