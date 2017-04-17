namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    public static class HelpScreen
    {
        public static void Draw()
        {
            Console.Clear();

            TitleScreen.DrawTitle();
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("@ - Character");
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(". - Floor");
            Console.SetCursorPosition(55, 17);
            Console.WriteLine("% - Item");
            Console.SetCursorPosition(55, 18);
            Console.WriteLine("$ - Money");
            Console.SetCursorPosition(55, 19);
            Console.WriteLine("+ - Locked Door");
            Console.SetCursorPosition(45, 20);
            Console.WriteLine("Alphabet letters are the enemies");
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("You can move your character with the arrow keys or the WASD keys.");
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("You can attack using the X key ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(59, 22);
            Console.WriteLine("Back");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
