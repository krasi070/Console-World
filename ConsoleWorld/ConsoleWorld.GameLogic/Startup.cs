namespace ConsoleWorld.GameLogic
{
    using System;
    using Screens;

    public class Startup
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            ScreenHandler handler = new ScreenHandler();
            TitleScreen.Draw();
            handler.SelectOptionFromTitleScreen();
        }
    }
}