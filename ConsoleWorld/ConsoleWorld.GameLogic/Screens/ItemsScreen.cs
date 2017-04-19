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
        private const int TitleX = 29;
        private const int TitleY = 0;
        private const int OptionsX = 0;
        private const int OptionsY = 0;
        private const int SelectLength = 3;
        private static string currItem = "";
        public static void ListItems()
        {
            //List<CharacterItem> items = Utility.GetItems();
            CharacterItem i1 = new CharacterItem()
            {
                CharacterId = 1,
                ItemId = 5
            };
            CharacterItem i2 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4
            };

            List<CharacterItem> items = new List<CharacterItem>();
            CharacterItem i3 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4,

            };
            CharacterItem i4 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4,

            };
            items.Add(i2);
            items.Add(i1);
            items.Add(i4);
            items.Add(i3);
            Console.WriteLine("");
            int i = 0;            
            foreach (var item in items)
            {
                Console.SetCursorPosition(OptionsX, OptionsY+i);
                Console.WriteLine(' ' + item.ItemId.ToString() + ' ');
                i++;
            }
            currItem = items.ElementAt(0).ItemId.ToString();
            Highlight(0);
        }

        public static void SelectOption()
        {
            //List<CharacterItem> items = Utility.GetItems();
            CharacterItem i1 = new CharacterItem()
            {
                CharacterId = 1,
                ItemId = 5
            };
            CharacterItem i2 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4,
                
            };
            CharacterItem i3 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4,

            };
            CharacterItem i4 = new CharacterItem()
            {
                CharacterId = 2,
                ItemId = 4,

            };

            List<CharacterItem> items = new List<CharacterItem>();
            items.Add(i2);
            items.Add(i1);
            items.Add(i4);
            items.Add(i3);

            ConsoleKey key = Console.ReadKey(true).Key;

            int count = 0;

            while (key != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            count = count % items.Count();
                            Console.SetCursorPosition(OptionsX, count);

                            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            count++;

                            count = count % items.Count();
                            currItem = items.ElementAt(count).ItemId.ToString();
                            Highlight(count);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            count = count % items.Count();
                            Console.SetCursorPosition(OptionsX, OptionsY + count);
                            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            count--;
                            if (count < 0)
                            {
                                count = items.Count() -1;
                            }
                            count = count % items.Count();
                            currItem = items.ElementAt(count).ItemId.ToString();
                            Highlight(count);
                            
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
        public static void Highlight(int i)
        {
            Console.SetCursorPosition(OptionsX, OptionsY + i);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
