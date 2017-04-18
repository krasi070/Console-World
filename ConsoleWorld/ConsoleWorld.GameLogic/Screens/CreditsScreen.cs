namespace ConsoleWorld.GameLogic.Screens
{
    using System;

    public static class CreditsScreen
    {
        private const int TextX = 53;
        private const int TextY = 17;

        public static void Draw()
        {
            Console.Clear();

            TitleScreen.DrawTitle();
            Console.SetCursorPosition(TextX, TextY);
            Console.WriteLine("Game Developers:");
            Console.SetCursorPosition(TextX, TextY + 2);
            Console.WriteLine("Krasimir Balchev");
            Console.SetCursorPosition(TextX, TextY + 3);
            Console.WriteLine("Ivan Stoyanov");
            Console.SetCursorPosition(TextX, TextY + 4);
            Console.WriteLine("Konstantin Filosofov");
            Console.SetCursorPosition(TextX, TextY + 5);
            Console.WriteLine("Martin Atanasov");
            Console.SetCursorPosition(TextX, TextY + 6);
            Console.WriteLine("Antonio Buyukliev");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(TextX + 3, TextY + 8);
            Console.WriteLine("   Back   ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}