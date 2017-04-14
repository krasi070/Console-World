namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using Enums;

    public static class TitleScreen
    {
        private const int TitleX = 29;
        private const int TitleY = 0;
        private const int OptionsX = 52;
        private const int OptionsY = 20;
        private const int SelectLength = 16;
        private const int NumberOfOptions = 4;

        public static TitleScreenOption CurrentOption { get; set; }
        
        public static void Draw()
        {
            Console.Clear();
            DrawTitle();
            HighlightOption(TitleScreenOption.Start);
            RemoveHighlight(TitleScreenOption.Help);
            RemoveHighlight(TitleScreenOption.Credits);
            RemoveHighlight(TitleScreenOption.Exit);
        }

        public static void DrawTitle()
        {
            Console.SetCursorPosition(TitleX, TitleY);
            Console.Write(" ______" + new string(' ', 43) + "_");
            Console.SetCursorPosition(TitleX, TitleY + 1);
            Console.Write("/::::::\\" + new string(' ', 41) + "|:|");
            Console.SetCursorPosition(TitleX, TitleY + 2);
            Console.Write("|x|" + new string(' ', 9) + "_____" + new string(' ', 4) + "_     _" + new string(' ', 4) + "____" + new string(' ', 4) + "_____" + new string(' ', 4) + "|x|" + new string(' ', 3) + "_____");
            Console.SetCursorPosition(TitleX, TitleY + 3);
            Console.Write("|x|" + new string(' ', 8) + "/:::::\\" + new string(' ', 2) + "|:\\\\   :|" + new string(' ', 2) + "/::::\\" + new string(' ', 2) + "/:::::\\" + new string(' ', 2) + " |x|" + new string(' ', 2) + "/::_::\\");
            Console.SetCursorPosition(TitleX, TitleY + 4);
            Console.Write("|x|" + new string(' ', 8) + "|x| |x|" + new string(' ', 2) + "|x \\\\  x|" + new string(' ', 2) + "|x___ " + new string(' ', 2) + "|x| |x|" + new string(' ', 2) + " |x|" + new string(' ', 2) + "|x|_)x|");
            Console.SetCursorPosition(TitleX, TitleY + 5);
            Console.Write("|x|" + new string(' ', 8) + "|x| |x|" + new string(' ', 2) + "|x  \\\\ x|" + new string(' ', 2) + " ___x|" + new string(' ', 2) + "|x| |x|" + new string(' ', 2) + " |x|" + new string(' ', 2) + "|x|____");
            Console.SetCursorPosition(TitleX, TitleY + 6);
            Console.Write("\\xxxxxx/" + new string(' ', 3) + "\\xxxxx/" + new string(' ', 2) + "|x   \\\\x|" + new string(' ', 2) + "/xxxx|" + new string(' ', 2) + "\\xxxxx/" + new string(' ', 2) + " |x|" + new string(' ', 2) + "\\xxxxx/");
            Console.SetCursorPosition(TitleX + 1, TitleY + 7);
            Console.Write("__" + new string(' ', 17) + "__" + new string(' ', 23) + "_" + new string(' ', 10) + "_");
            Console.SetCursorPosition(TitleX + 1, TitleY + 8);
            Console.Write("\\:\\" + new string(' ', 15) + "/:/" + new string(' ', 22) + "|:|" + new string(' ', 8) + "|:\\");
            Console.SetCursorPosition(TitleX + 1, TitleY + 9);
            Console.Write(new string(' ', 1) + "\\x\\" + new string(' ', 13) + "/x/" + new string(' ', 4) + "_____" + new string(' ', 4) + "_  ____" + new string(' ', 3) + "|x|" + new string(' ', 8) + "|x|");
            Console.SetCursorPosition(TitleX + 1, TitleY + 10);
            Console.Write(new string(' ', 2) + "\\x\\" + new string(' ', 4) + "xxx" + new string(' ', 4) + "/x/" + new string(' ', 4) + "/:::::\\" + new string(' ', 2) + "\\:|/::::\\" + new string(' ', 2) + "|x|" + new string(' ', 3) + "____ |x|");
            Console.SetCursorPosition(TitleX + 1, TitleY + 11);
            Console.Write(new string(' ', 3) + "\\x\\" + new string(' ', 2) + "x/ \\x" + new string(' ', 2) + "/x/" + new string(' ', 5) + "|x| |x|" + new string(' ', 2) + "|x|   \\x|" + new string(' ', 2) + "|x|" + new string(' ', 2) + "/xxxx\\|x|");
            Console.SetCursorPosition(TitleX + 1, TitleY + 12);
            Console.Write(new string(' ', 4) + "\\x\\x/" + new string(' ', 3) + "\\x/x/" + new string(' ', 6) + "|x| |x|" + new string(' ', 2) + "|x|" + new string(' ', 8) + "|x|" + new string(' ', 2) + "||  |||x|");
            Console.SetCursorPosition(TitleX + 1, TitleY + 13);
            Console.Write(new string(' ', 5) + "\\x/" + new string(' ', 5) + "\\x/" + new string(' ', 7) + "\\xxxxx/" + new string(' ', 2) + "/xxx\\" + new string(' ', 6) + "|x|" + new string(' ', 2) + "\\xxxx/\\xx\\");
        }

        public static void SelectOption()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Enter)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                    {                        
                        RemoveHighlight(CurrentOption);
                        CurrentOption = (TitleScreenOption)((int)(CurrentOption + 1) % NumberOfOptions);
                        HighlightOption(CurrentOption);
                    }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                    {
                        RemoveHighlight(CurrentOption);
                        CurrentOption = CurrentOption - 1 < 0
                            ? TitleScreenOption.Exit
                            : (TitleScreenOption)(CurrentOption - 1);
                        HighlightOption(CurrentOption);
                    }
                        break;
                }
                
                key = Console.ReadKey(true).Key;
            }
        }

        private static void HighlightOption(TitleScreenOption option)
        {
            if (option == TitleScreenOption.Start)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Start".Length) / 2) + "Start" + new string(' ', (SelectLength - "Start".Length) / 2 + (SelectLength - "Start".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (option == TitleScreenOption.Help)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Help".Length) / 2) + "Help" + new string(' ', (SelectLength - "Help".Length) / 2 + (SelectLength - "Hepl".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (option == TitleScreenOption.Credits)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Credits".Length) / 2) + "Credits" + new string(' ', (SelectLength - "Credits".Length) / 2 + (SelectLength - "Credits".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (option == TitleScreenOption.Exit)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Exit".Length) / 2) + "Exit" + new string(' ', (SelectLength - "Exit".Length) / 2 + (SelectLength - "Exit".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void RemoveHighlight(TitleScreenOption option)
        {
            if (option == TitleScreenOption.Start)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.WriteLine(new string(' ', (SelectLength - "Start".Length) / 2) + "Start" + new string(' ', (SelectLength - "Start".Length) / 2 + (SelectLength - "Start".Length) % 2));
            }

            if (option == TitleScreenOption.Help)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.WriteLine(new string(' ', (SelectLength - "Help".Length) / 2) + "Help" + new string(' ', (SelectLength - "Help".Length) / 2 + (SelectLength - "Help".Length) % 2));
            }

            if (option == TitleScreenOption.Credits)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.WriteLine(new string(' ', (SelectLength - "Credits".Length) / 2) + "Credits" + new string(' ', (SelectLength - "Credits".Length) / 2 + (SelectLength - "Credits".Length) % 2));
            }

            if (option == TitleScreenOption.Exit)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Exit".Length) / 2) + "Exit" + new string(' ', (SelectLength - "Exit".Length) / 2 + (SelectLength - "Exit".Length) % 2));
            }
        }
    }
}