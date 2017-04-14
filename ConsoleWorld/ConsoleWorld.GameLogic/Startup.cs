namespace ConsoleWorld.GameLogic
{
    using System;
    using ConsoleWorld.GameLogic.Menus;
    class Startup
    {
        static void Main()
        {
            Console.CursorVisible = false;
            StartMenu Menu= new StartMenu();
            Menu.Draw();
            Menu.ChooseOption();
        }
    }
}
