using ConsoleWorld.GameLogic.Menus.Enums;

namespace ConsoleWorld.GameLogic.Menus
{
    using System;
    public class LoadCreateGameMenu
    {
        public LoadCreateGameMenuOption CurrentOption { get; set; }
        private const int length = 9;

        public LoadCreateGameMenu(LoadCreateGameMenuOption option = LoadCreateGameMenuOption.LoadGame)
        {
            this.CurrentOption = option;
        }

        public void DrawLoadCreateGame()
        {
            Console.Clear();
            StartMenu.DrawTitle();
            if (CurrentOption == LoadCreateGameMenuOption.LoadGame)
            {
                LoadGameChosen();
            }
            if (CurrentOption == LoadCreateGameMenuOption.NewGame)
            {
                NewGameChosen();
            }
            if (CurrentOption == LoadCreateGameMenuOption.Back)
            {
                BackChosen();
            }
        }

        public void ChooseOption()
        {
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            CurrentOption = (LoadCreateGameMenuOption)((int)(CurrentOption + 1) % 3);
                            if (CurrentOption == LoadCreateGameMenuOption.LoadGame)
                            {
                                LoadGameChosen();
                            }
                            if (CurrentOption == LoadCreateGameMenuOption.NewGame)
                            {
                                NewGameChosen();
                            }
                            if (CurrentOption == LoadCreateGameMenuOption.Back)
                            {
                                BackChosen();
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            CurrentOption = this.CurrentOption - 1 < 0
                                ? LoadCreateGameMenuOption.Back
                                : (LoadCreateGameMenuOption)(this.CurrentOption - 1);
                            if (CurrentOption == LoadCreateGameMenuOption.LoadGame)
                            {
                                LoadGameChosen();
                            }
                            if (CurrentOption == LoadCreateGameMenuOption.NewGame)
                            {
                                NewGameChosen();
                            }
                            if (CurrentOption == LoadCreateGameMenuOption.Back)
                            {
                                BackChosen();
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            switch (CurrentOption)
                            {
                                case LoadCreateGameMenuOption.Back:
                                {
                                        Console.CursorVisible = false;
                                        StartMenu Menu = new StartMenu();
                                        Menu.Draw();
                                        Menu.ChooseOption();
                                }
                                    break;
                                case LoadCreateGameMenuOption.NewGame:
                                {
                                    var create = new CreateGameMenu();
                                        create.DrawCreateGameMenu();
                                        create.ChooseOption();
                                }
                                    break;
                            }
                        }
                        break;
                }
                key = Console.ReadKey().Key;
            }
        }
        public static void LoadGameChosen()
        {
            Console.SetCursorPosition(55, 15);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(new string(' ', (length - "Load Game".Length) / 2) + "Load Game" + new string(' ', (length - "Load Game".Length) / 2 + (length - "Load Game".Length) % 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(new string(' ', (length - "New Game".Length) / 2) + "New Game" + new string(' ', (length - "New Game".Length) / 2 + (length - "New Game".Length) % 2));
            Console.SetCursorPosition(55, 17);
            Console.WriteLine(new string(' ', (length - "Back".Length) / 2) + "Back" + new string(' ', (length - "Back".Length) / 2 + (length - "Back".Length) % 2));
        }
        public static void NewGameChosen()
        {
            Console.SetCursorPosition(55, 15);
            Console.WriteLine(new string(' ', (length - "Load Game".Length) / 2) + "Load Game" + new string(' ', (length - "Load Game".Length) / 2 + (length - "Load Game".Length) % 2));
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(new string(' ', (length - "New Game".Length) / 2) + "New Game" + new string(' ', (length - "New Game".Length) / 2 + (length - "New Game".Length) % 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;            
            Console.SetCursorPosition(55, 17);
            Console.WriteLine(new string(' ', (length - "Back".Length) / 2) + "Back" + new string(' ', (length - "Back".Length) / 2 + (length - "Back".Length) % 2));
        }
        public static void BackChosen()
        {
            Console.SetCursorPosition(55, 15);
            Console.WriteLine(new string(' ', (length - "Load Game".Length) / 2) + "Load Game" + new string(' ', (length - "Load Game".Length) / 2 + (length - "Load Game".Length) % 2));
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(new string(' ', (length - "New Game".Length) / 2) + "New Game" + new string(' ', (length - "New Game".Length) / 2 + (length - "New Game".Length) % 2));
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(55, 17);
            Console.WriteLine(new string(' ', (length - "Back".Length) / 2) + "Back" + new string(' ', (length - "Back".Length) / 2 + (length - "Back".Length) % 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
