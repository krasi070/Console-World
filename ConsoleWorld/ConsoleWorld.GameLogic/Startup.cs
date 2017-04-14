namespace ConsoleWorld.GameLogic
{
    using System;

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
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }
    }
}