namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using Enums;
    public static class StartMenuScreen
    {
        private const int OptionsX = 52;
        private const int OptionsY = 20;
        private const int SelectLength = 16;
        private const int NumberOfOptions = 3;

        public static StartMenuOption CurrentOption { get; set; }

        public static void Draw()
        {
            Console.Clear();
            TitleScreen.DrawTitle();
            RemoveHighlight(StartMenuOption.LoadGame);
            HighlightOption(StartMenuOption.NewGame);
            RemoveHighlight(StartMenuOption.Back);
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
                            CurrentOption = (StartMenuOption)((int)(CurrentOption + 1) % NumberOfOptions);
                            HighlightOption(CurrentOption);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            RemoveHighlight(CurrentOption);
                            CurrentOption = CurrentOption - 1 < 0
                                ? StartMenuOption.Back
                                : (StartMenuOption)(CurrentOption - 1);
                            HighlightOption(CurrentOption);
                        }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }
        }

        private static void HighlightOption(StartMenuOption option)
        {
            if (option == StartMenuOption.LoadGame)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Load Game".Length) / 2) + "Load Game" + new string(' ', (SelectLength - "Load Game".Length) / 2 + (SelectLength - "Load Game".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (option == StartMenuOption.NewGame)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.WriteLine(new string(' ', (SelectLength - "New Game".Length) / 2) + "New Game" + new string(' ', (SelectLength - "New Game".Length) / 2 + (SelectLength - "New Game".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (option == StartMenuOption.Back)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void RemoveHighlight(StartMenuOption option)
        {
            if (option == StartMenuOption.LoadGame)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.WriteLine(new string(' ', (SelectLength - "Load Game".Length) / 2) + "Load Game" + new string(' ', (SelectLength - "Load Game".Length) / 2 + (SelectLength - "Load Game".Length) % 2));
            }

            if (option == StartMenuOption.NewGame)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.WriteLine(new string(' ', (SelectLength - "New Game".Length) / 2) + "New Game" + new string(' ', (SelectLength - "New Game".Length) / 2 + (SelectLength - "New Game".Length) % 2));
            }

            if (option == StartMenuOption.Back)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
            }
        }
    }
}