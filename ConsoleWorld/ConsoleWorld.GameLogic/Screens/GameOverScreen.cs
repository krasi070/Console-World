using System.Text;
using System.Threading.Tasks;
using System;

namespace ConsoleWorld.GameLogic.Screens
{
    public static class GameOverScreen
    {
        private const int TitleX = 35;
        private const int TitleY = 0;
        private const int OptionsX = 52;
        private const int OptionsY = 18;

        public static void Draw()
        {
            Console.SetCursorPosition(TitleX, TitleY);
            Console.WriteLine(" ______");
            Console.SetCursorPosition(TitleX, TitleY + 1);
            Console.WriteLine("/::::::\\" + new string(' ', 4) + "________" + new string(' ', 6) + "_  ___  ___" + new string(' ', 5) + "_______");
            Console.SetCursorPosition(TitleX, TitleY + 2);
            Console.WriteLine("|x|" + new string(' ', 9) + "\\:::::::\\" + new string(' ', 4) + "|:|/:::\\/:::\\" + new string(' ', 3) + "/:::::::\\");
            Console.SetCursorPosition(TitleX, TitleY + 3);
            Console.WriteLine("|x| _____" + new string(' ', 4) + "_____ \\x|" + new string(' ', 3) + "|x|   |x|  |x|" + new string(' ', 2) + "|x|    )x|");
            Console.SetCursorPosition(TitleX, TitleY + 4);
            Console.WriteLine("|x||xxxxx|" + new string(' ', 2) + "/xxxxx\\|x|" + new string(' ', 3) + "|x|   |x|  |x|" + new string(' ', 2) + "|xxxxxxxx|");
            Console.SetCursorPosition(TitleX, TitleY + 5);
            Console.WriteLine("|x|  |x|" + new string(' ', 3) + "|x(_____|x|" + new string(' ', 3) + "|x|   |x|  |x|" + new string(' ', 2) + "|x|______");
            Console.SetCursorPosition(TitleX, TitleY + 6);
            Console.WriteLine("\\xxxxxx/" + new string(' ', 4) + "\\xxxxxx/\\x\\" + new string(' ', 2) + "|x|   |x|  |x|" + new string(' ', 2) + "\\xxxxxxx/");
            Console.SetCursorPosition(TitleX + 2, TitleY + 8);
            Console.WriteLine(" ______");
            Console.SetCursorPosition(TitleX + 2, TitleY + 9);
            Console.WriteLine("/::::::\\" + new string(' ', 3) + "_        _" + new string(' ', 4) + "_______" + new string(' ', 4) + "___  ____");
            Console.SetCursorPosition(TitleX + 2, TitleY + 10);
            Console.WriteLine("|x|  |x|" + new string(' ', 2) + "\\:\\      /:/" + new string(' ', 2) + "/:::::::\\" + new string(' ', 3) + "\\::|/::::\\");
            Console.SetCursorPosition(TitleX + 2, TitleY + 11);
            Console.WriteLine("|x|  |x|" + new string(' ', 3) + "\\x\\    /x/" + new string(' ', 3) + "|x|    )x|" + new string(' ', 3) + "|x|   \\x|");
            Console.SetCursorPosition(TitleX + 2, TitleY + 12);
            Console.WriteLine("|x|  |x|" + new string(' ', 4) + "\\x\\  /x/" + new string(' ', 4) + "|xxxxxxxx|" + new string(' ', 3) + "|x|");
            Console.SetCursorPosition(TitleX + 2, TitleY + 13);
            Console.WriteLine("|x|  |x|" + new string(' ', 5) + "\\x\\/x/" + new string(' ', 5) + "|x|______" + new string(' ', 4) + "|x|");
            Console.SetCursorPosition(TitleX + 2, TitleY + 14);
            Console.WriteLine("\\xxxxxx/" + new string(' ', 6) + "\\xx/" + new string(' ', 6) + "\\xxxxxxx/" + new string(' ', 3) + "/xxx\\");


            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(OptionsX, OptionsY);
            Console.WriteLine("Back To Main Menu");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void BackToTitleScreen()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    TitleScreen.Draw();
                    break;
                }
            }
        }
    }
}