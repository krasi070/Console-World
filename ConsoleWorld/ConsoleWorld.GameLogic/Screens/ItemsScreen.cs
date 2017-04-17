namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using Data;
    using Enums;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    public class ItemsScreen
    {
        private static ConsoleWorldContext ctx = new ConsoleWorldContext();
        private const int TitleX = 29;
        private const int TitleY = 0;
        private const int OptionsX = 52;
        private const int OptionsY = 20;
        private const int SelectLength = 16;
        public static int NumberOfOptions = ctx.CharacterItems.Count();
        public static void ListItems()
        {
            var items = ctx.CharacterItems.OrderBy(n=>n.Item.Name);
                                 
            foreach (var item in items)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.WriteLine(item.Item.Name);                
            }
        }
        public static void SelectOption()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            var items = ctx.CharacterItems.OrderBy(n => n.Item.Name).AsEnumerable();
            int count = 0;

            while (key != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            if(count > 50 - OptionsY - 1)
                            {
                                count = 0;
                            }
                            var currItem = items.ElementAt(count);
                            Console.SetCursorPosition(OptionsX, OptionsY + count);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            count++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            if (count < 0)
                            {
                                count = 50 - OptionsY - 1;
                            }
                            var currItem = items.ElementAt(count);

                            Console.SetCursorPosition(OptionsX, OptionsY + count);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            count--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            if (true)
                            {
                                //TODO: Equip the item
                            }
                        }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }
        }

    }
}
