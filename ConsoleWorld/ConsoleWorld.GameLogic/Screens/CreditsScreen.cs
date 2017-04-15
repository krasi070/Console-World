namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    public class CreditsScreen
    {
        public static void Draw()
        {
            Console.Clear();

            TitleScreen.DrawTitle();
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("Game Developers:");
            Console.SetCursorPosition(55, 17);
            Console.WriteLine("Krasimir Balchev");
            Console.SetCursorPosition(55, 18);
            Console.WriteLine("Ivan Stoyanov");
            Console.SetCursorPosition(55, 19);
            Console.WriteLine("Konstantin Filosofov");
            Console.SetCursorPosition(55, 20);
            Console.WriteLine("Martin Atanasov");
            Console.SetCursorPosition(55, 21);
            Console.WriteLine("Antonio Buyukliev");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(59, 23);
            Console.WriteLine("Back");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
