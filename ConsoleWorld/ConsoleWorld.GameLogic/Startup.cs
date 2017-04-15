namespace ConsoleWorld.GameLogic
{
    using System;
    using Core;

    public class Startup
    {
        public static void Main()
        {
            SetConsoleValues();
            Engine engine = new Engine();
            engine.Run();
        }

        private static void SetConsoleValues()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }
    }
}