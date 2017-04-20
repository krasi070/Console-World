using ConsoleWorld.Models.Enums;

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
        private const int OptionsX = 20;
        private const int OptionsY = 10;
        private const int QuantityX = 60;
        private const int QuantityY = 10;
        private const int SelectLength = 20;
        private static string currItem = "";

        public static Character currentCharacter { get; set; }

        public static void ListItems(Character character)
        {
            Dictionary<string, int> dictionary= Utility.GetCharacterItems(character.Id);
            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("Select an item you'd like to use. Click enter to use the item.");
            int i = 0;
            currItem = dictionary.Keys.First();
            
            foreach (var item in dictionary)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + i);
                Console.WriteLine(new string(' ', (SelectLength - item.Key.Length) / 2) + item.Key + new string(' ', (SelectLength - item.Key.Length) / 2 + (SelectLength - item.Key.Length) % 2));
                i++;
            }

            Highlight(0, dictionary);

        }

        public static bool SelectOption(Character character)
        {
            Dictionary<string, int> dictionary = Utility.GetCharacterItems(character.Id);
            //CharacterItem i1 = new CharacterItem()
            //{
            //    CharacterId = 1,
            //    ItemId = 5,Quantity = 1
            //};
            //CharacterItem i2 = new CharacterItem()
            //{
            //    CharacterId = 2,
            //    ItemId = 4,

            //};
            //CharacterItem i3 = new CharacterItem()
            //{
            //    CharacterId = 2,
            //    ItemId = 4,

            //};
            //CharacterItem i4 = new CharacterItem()
            //{
            //    CharacterId = 2,
            //    ItemId = 4,

            //};

            //List<CharacterItem> items = new List<CharacterItem>();
            //items.Add(i2);
            //items.Add(i1);
            //items.Add(i4);
            //items.Add(i3);

            ConsoleKey key = Console.ReadKey(true).Key;

            int count = 0;

            while (key != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            count = count % dictionary.Keys.Count();
                            Console.SetCursorPosition(OptionsX, count + OptionsY);

                            Console.WriteLine(new string(' ', (SelectLength - currItem.Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            count++;

                            count = count % dictionary.Keys.Count();
                            currItem = dictionary.Keys.ElementAt(count);
                            Highlight(count,dictionary);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            count = count % dictionary.Keys.Count();
                            Console.SetCursorPosition(OptionsX, OptionsY + count);
                            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
                            count--;
                            if (count < 0)
                            {
                                count = dictionary.Keys.Count() -1;
                            }
                            count = count % dictionary.Keys.Count();
                            currItem = dictionary.Keys.ElementAt(count);
                            Highlight(count,dictionary);
                            
                        }
                        break;
                    case ConsoleKey.Enter:
                    {
                        if (currItem != "Back" && dictionary[currItem] > 0)
                        {
                            var item = Utility.GetItem(currItem);
                            if (item.Type == ItemType.Hp)
                            {
                                character.Hp += Math.Min(character.MaxHp,
                                    character.Hp + item.PercentageIncrease * character.Hp / 100);
                                    
                            }

                            if (item.Type == ItemType.Mp)
                            {
                                character.Mp += Math.Min(character.MaxMp,
                                    character.Mp + item.PercentageIncrease * character.Mp / 100);
                            }
                            Utility.RemoveOneItemFromCharacter(character.Id,currItem);
                            dictionary[currItem] -= 1;
                                Highlight(count,dictionary);
                        }
                            else if (currItem == "Back")
                        {
                                return true;
                            }
                    }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }
            return false;
        }
        public static void Highlight(int i, Dictionary<string, int> its)
        {
            Console.SetCursorPosition(OptionsX, OptionsY + i);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(new string(' ', (SelectLength - currItem.ToString().Length) / 2) + currItem.ToString() + new string(' ', (SelectLength - currItem.ToString().Length) / 2 + (SelectLength - currItem.ToString().Length) % 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(QuantityX, QuantityY);
            Console.Write(new string(' ', 40));
            if (its[its.Keys.ElementAt(i)] >= 0)
            {
                
                Console.SetCursorPosition(QuantityX, QuantityY);
                Console.Write($"Quantity: {its[its.Keys.ElementAt(i)]}");
            }
        }
    }
}
