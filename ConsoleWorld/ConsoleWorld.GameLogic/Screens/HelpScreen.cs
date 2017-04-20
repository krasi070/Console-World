namespace ConsoleWorld.GameLogic.Screens
{
    using System;

    public static class HelpScreen
    {
        private const int TextX = 55;
        private const int TextY = 16;

        public static void Draw()
        {
            Console.Clear();

            TitleScreen.DrawTitle();
            Console.SetCursorPosition(TextX, TextY);
            Console.WriteLine("@ - Character");
            Console.SetCursorPosition(TextX, TextY + 1);
            Console.WriteLine(". - Floor");
            Console.SetCursorPosition(TextX, TextY + 2);
            Console.WriteLine("% - Item");
            Console.SetCursorPosition(TextX, TextY + 3);
            Console.WriteLine("$ - Money");
            Console.SetCursorPosition(TextX, TextY + 4);
            Console.WriteLine("+ - Locked Door");
            Console.SetCursorPosition(TextX, TextY + 5);
            Console.WriteLine("= - Magic Well");
            Console.SetCursorPosition(TextX, TextY + 6);
            Console.WriteLine("o - Hole to lower floor");
            Console.SetCursorPosition(TextX - 6, TextY + 7);
            Console.WriteLine("Alphabet letters are the enemies.");
            Console.SetCursorPosition(TextX - 23, TextY + 8);
            Console.WriteLine("You can move your character with the arrow keys or the WASD keys.");
            Console.SetCursorPosition(TextX - 30, TextY + 9);
            Console.WriteLine("You can attack using the K key and you can upgrade your stats with the O key.");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(TextX + 1, TextY + 11);
            Console.WriteLine("   Back   ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}