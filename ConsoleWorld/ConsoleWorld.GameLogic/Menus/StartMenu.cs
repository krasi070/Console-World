using System;
using ConsoleWorld.GameLogic.Menus.Enums;

namespace ConsoleWorld.GameLogic.Menus
{
    public class StartMenu
    {
        public StartMenu(StartMenuOption currentOption=StartMenuOption.Start)
        {
            this.CurrentOption = currentOption;
        }
        public StartMenuOption CurrentOption { get; set; }
        private int length = 7;
        public void Draw()
        {
            Console.Clear();
            DrawTitle();
            Console.SetCursorPosition(55, 15);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor= ConsoleColor.Black;
            Console.WriteLine(new string(' ',(length-"Start".Length)/2)+"Start"+ new string(' ', (length - "Start".Length) / 2 + (7 - "Start".Length)%2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(new string(' ', (length - "Help".Length) / 2) + "Help" + new string(' ', (length - "Help".Length) / 2 + (7 - "Help".Length) % 2));
            Console.SetCursorPosition(55, 17);
            Console.WriteLine("Credits");
            Console.SetCursorPosition(55, 18);
            Console.WriteLine(new string(' ', (length - "Exit".Length) / 2) + "Exit" + new string(' ', (length - "Exit".Length) / 2 + (7 - "Exit".Length) % 2));


        }

        public void DrawTitle()
        {
            Console.SetCursorPosition(25, 0);
            Console.Write(" ______" + new string(' ', 43) + "_");
            Console.SetCursorPosition(25, 1);
            Console.Write("/::::::\\" + new string(' ', 41) + "|:|");
            Console.SetCursorPosition(25, 2);
            Console.Write("|x|" + new string(' ', 9) + "_____" + new string(' ', 4) + "_     _" + new string(' ', 4) + "____" + new string(' ', 4) + "_____" + new string(' ', 4) + "|x|" + new string(' ', 3) + "_____");
            Console.SetCursorPosition(25, 3);
            Console.Write("|x|" + new string(' ', 8) + "/:::::\\" + new string(' ', 2) + "|:\\\\   :|" + new string(' ', 2) + "/::::\\" + new string(' ', 2) + "/:::::\\" + new string(' ', 2) + " |x|" + new string(' ', 2) + "/::_::\\");
            Console.SetCursorPosition(25, 4);
            Console.Write("|x|" + new string(' ', 8) + "|x| |x|" + new string(' ', 2) + "|x \\\\  x|" + new string(' ', 2) + "|x___ " + new string(' ', 2) + "|x| |x|" + new string(' ', 2) + " |x|" + new string(' ', 2) + "|x|_)x|");
            Console.SetCursorPosition(25, 5);
            Console.Write("|x|" + new string(' ', 8) + "|x| |x|" + new string(' ', 2) + "|x  \\\\ x|" + new string(' ', 2) + " ___x|" + new string(' ', 2) + "|x| |x|" + new string(' ', 2) + " |x|" + new string(' ', 2) + "|x|____");
            Console.SetCursorPosition(25, 6);
            Console.Write("\\xxxxxx/" + new string(' ', 3) + "\\xxxxx/" + new string(' ', 2) + "|x   \\\\x|" + new string(' ', 2) + "/xxxx|" + new string(' ', 2) + "\\xxxxx/" + new string(' ', 2) + " |x|" + new string(' ', 2) + "\\xxxxx/");
            Console.SetCursorPosition(26, 7);
            Console.Write("__" + new string(' ', 17) + "__" + new string(' ', 23) + "_" + new string(' ', 10) + "_");
            Console.SetCursorPosition(26, 8);
            Console.Write("\\:\\" + new string(' ', 15) + "/:/" + new string(' ', 22) + "|:|" + new string(' ', 8) + "|:\\");
            Console.SetCursorPosition(26, 9);
            Console.Write(new string(' ', 1) + "\\x\\" + new string(' ', 13) + "/x/" + new string(' ', 4) + "_____" + new string(' ', 4) + "_  ____" + new string(' ', 3) + "|x|" + new string(' ', 8) + "|x|");
            Console.SetCursorPosition(26, 10);
            Console.Write(new string(' ', 2) + "\\x\\" + new string(' ', 4) + "xxx" + new string(' ', 4) + "/x/" + new string(' ', 4) + "/:::::\\" + new string(' ', 2) + "\\:|/::::\\" + new string(' ', 2) + "|x|" + new string(' ', 3) + "____ |x|");
            Console.SetCursorPosition(26, 11);
            Console.Write(new string(' ', 3) + "\\x\\" + new string(' ', 2) + "x/ \\x" + new string(' ', 2) + "/x/" + new string(' ', 5) + "|x| |x|" + new string(' ', 2) + "|x|   \\x|" + new string(' ', 2) + "|x|" + new string(' ', 2) + "/xxxx\\|x|");
            Console.SetCursorPosition(26, 12);
            Console.Write(new string(' ', 4) + "\\x\\x/" + new string(' ', 3) + "\\x/x/" + new string(' ', 6) + "|x| |x|" + new string(' ', 2) + "|x|" + new string(' ', 8) + "|x|" + new string(' ', 2) + "||  |||x|");
            Console.SetCursorPosition(26, 13);
            Console.Write(new string(' ', 5) + "\\x/" + new string(' ', 5) + "\\x/" + new string(' ', 7) + "\\xxxxx/" + new string(' ', 2) + "/xxx\\" + new string(' ', 6) + "|x|" + new string(' ', 2) + "\\xxxx/\\xx\\");

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
                            TurnOptionToUnchoosed(CurrentOption);
                        CurrentOption = (StartMenuOption) ((int) (this.CurrentOption + 1) % 4);
                            TurnOptionToChoosed(CurrentOption);
                    }
                        break;
                    case ConsoleKey.UpArrow:
                    {
                            TurnOptionToUnchoosed(CurrentOption);
                        CurrentOption = this.CurrentOption - 1 < 0
                            ? StartMenuOption.Exit
                            : (StartMenuOption) (this.CurrentOption - 1);
                            TurnOptionToChoosed(CurrentOption);
                    }
                        break;
                }
                
                key = Console.ReadKey().Key;
            }
        }

        public void TurnOptionToChoosed(StartMenuOption option)
        {
            if (option == StartMenuOption.Start)
            {
                Console.SetCursorPosition(55, 15);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (length - "Start".Length) / 2) + "Start" + new string(' ', (length - "Start".Length) / 2 + (7 - "Start".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (option == StartMenuOption.Help)
            {
                Console.SetCursorPosition(55, 16);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (length - "Help".Length) / 2) + "Help" + new string(' ', (length - "Help".Length) / 2 + (7 - "Hepl".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (option == StartMenuOption.Credits)
            {
                Console.SetCursorPosition(55, 17);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Credits");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (option == StartMenuOption.Exit)
            {
                Console.SetCursorPosition(55, 18);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (length - "Exit".Length) / 2) + "Exit" + new string(' ', (length - "Exit".Length) / 2 + (7 - "Exit".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void TurnOptionToUnchoosed(StartMenuOption option)
        {
            if (option == StartMenuOption.Start)
            {
                Console.SetCursorPosition(55, 15);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string(' ', (length - "Start".Length) / 2) + "Start" + new string(' ', (length - "Start".Length) / 2 + (7 - "Start".Length) % 2));

            }
            if (option == StartMenuOption.Help)
            {
                Console.SetCursorPosition(55, 16);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string(' ', (length - "Help".Length) / 2) + "Help" + new string(' ', (length - "Help".Length) / 2 + (7 - "Help".Length) % 2));
            }
            if (option == StartMenuOption.Credits)
            {
                Console.SetCursorPosition(55, 17);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Credits");
                
            }
            if (option == StartMenuOption.Exit)
            {
                Console.SetCursorPosition(55, 18);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string(' ', (length - "Exit".Length) / 2) + "Exit" + new string(' ', (length - "Exit".Length) / 2 + (7 - "Exit".Length) % 2));
            }
        }
    }
}
