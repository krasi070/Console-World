namespace ConsoleWorld.GameLogic.Screens
{
    using Models.Enums;
    using System;
    using System.Text;
    using Data;
    using System.Linq;
    using Models.Classes;
    using Models;

    public static class CharacterCreationScreen
    {
        private const int SelectLength = 12;
        private const int TextX = 20;
        private const int TextY = 16;
        private const int MinNameLength = 2;
        private const int MaxNameLength = 9;
        private const int NumberOfClasses = 6;
        private const int ClassesX = 20;
        private const int ClassesY = 18;
        private const int StatsX = 75;
        private const int StatsY = 17;
        private const int BackspaceCode = 8;
        private const int EnterCode = 13;

        private static string characterName = string.Empty;
        private static Class characterClass = Class.Knight;

        public static void Draw()
        {
            Console.Clear();
            TitleScreen.DrawTitle();
        }

        public static Character CreateCharacter()
        {
            NameCharacter();
            var character = SelectClass();

            return character;
        }

        private static Character SelectClass()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Enter)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            characterClass = (Class)((int)(characterClass + 1) % NumberOfClasses);
                            HighlightClass(characterClass.ToString());
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            characterClass = characterClass - 1 < 0
                            ? Class.Thief
                            : (Class)(characterClass - 1);
                            HighlightClass(characterClass.ToString());
                        }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }

            return CreateCharacterDb();
        }

        private static Character CreateCharacterDb()
        {
            var character = new Character();
            var ctx = new ConsoleWorldContext();
            if (characterClass.ToString() == "Archer")
            {
                character = new Archer();
            }
            else if (characterClass.ToString() == "Knight")
            {
                character = new Knight();
            }
            else if (characterClass.ToString() == "Magician")
            {
                character = new Magician();
            }
            else if (characterClass.ToString() == "Robot")
            {
                character = new Robot();
            }
            else if (characterClass.ToString() == "Thief")
            {
                character = new Thief();
            }
            else if (characterClass.ToString() == "Viking")
            {
                character = new Viking();
            }

            character.Name = characterName;
            ctx.Characters.Add(character);
            ctx.SaveChanges();

            return character;
        }

        private static void NameCharacter()
        {
            bool characterIsValid = false;
            while (!characterIsValid)
            {
                Console.CursorVisible = true;
                Console.SetCursorPosition(TextX, TextY);
                Console.Write("Character Name: ");
                StringBuilder sb = new StringBuilder();
                char ch = Console.ReadKey(true).KeyChar;
                while (ch == BackspaceCode) ch = Console.ReadKey(true).KeyChar;
                while (ch != EnterCode) 
                {
                    int backspace = TextX + "Character Name: ".Length + sb.Length;
                    if (sb.Length < MaxNameLength)
                    {
                        if (ch != BackspaceCode) Console.Write(ch);
                        if (ch == BackspaceCode && sb.Length >= 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.SetCursorPosition(backspace - 1, TextY);
                            Console.Write(" ");
                            Console.SetCursorPosition(backspace - 1, TextY);
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                    }
                    else if (sb.Length == MaxNameLength)
                    {
                        if (ch == BackspaceCode)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.SetCursorPosition(TextX + "Character Name: ".Length + MaxNameLength - 1, TextY);
                            Console.Write(" ");
                            Console.SetCursorPosition(TextX + "Character Name: ".Length + sb.Length, TextY);
                        }
                    }
                    ch = Console.ReadKey(true).KeyChar;
                }

                characterName = sb.ToString();

                if (characterName.Length > MinNameLength)
                {
                    var ctx = new ConsoleWorldContext();

                    if (ctx.Characters.Any(c => c.Name == characterName))
                    {
                        // TODO: Check if character exist
                        characterIsValid = false;
                    }
                    else
                    {
                        characterIsValid = true;

                        Console.SetCursorPosition(TextX, TextY + 1);
                        Console.WriteLine(new string(' ', "Invalid character name! Character name should be at least 3 symbols!".Length));
                    }
                }
                else
                {
                    Console.SetCursorPosition(TextX + "Character Name: ".Length, TextY);
                    Console.Write(new string(' ', MaxNameLength));
                    Console.SetCursorPosition(TextX, TextY + 1);
                    Console.WriteLine("Invalid character name! Character name should be at least 3 symbols!");
                }
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(TextX, TextY + 1);
            Console.WriteLine("Choose a class: ");
            HighlightClass(characterClass.ToString());
        }

        private static void HighlightClass(string className)
        {
            DrawClass(className);
            DrawStats(className);
        }

        private static void DrawClass(string className)
        {
            int i = 0;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == className)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(ClassesX, ClassesY + i);
                    Console.WriteLine(
                        new string(' ', (SelectLength - character.ToString().Length) / 2) + 
                        character +
                        new string(' ', (int)((SelectLength - character.ToString().Length) / 2.0)));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.SetCursorPosition(ClassesX, ClassesY + i);
                    Console.WriteLine(
                        new string(' ', (SelectLength - character.ToString().Length) / 2) +
                        character +
                        new string(' ', (int)((SelectLength - character.ToString().Length) / 2.0)));
                }

                i++;
            }
        }

        private static void DrawStats(string className)
        {
            Type type = Type.GetType($"ConsoleWorld.Models.Classes.{className},ConsoleWorld.Models");
            string hp = type.GetField("DefaultHp").GetValue(null).ToString();
            string mp = type.GetField("DefaultMp").GetValue(null).ToString();
            string attack = type.GetField("DefaultAttack").GetValue(null).ToString();
            string magicAttack = type.GetField("DefaultMagicAttack").GetValue(null).ToString();
            string defense = type.GetField("DefaultDefense").GetValue(null).ToString();
            string magicDefense = type.GetField("DefaultMagicDefense").GetValue(null).ToString();
            string evade = type.GetField("DefaultEvade").GetValue(null).ToString();
            string accuracy = type.GetField("DefaultAccuracy").GetValue(null).ToString();
            string range = type.GetField("DefaultRange").GetValue(null).ToString();

            Console.SetCursorPosition(StatsX, StatsY);
            Console.WriteLine("Health: " + hp + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 1);
            Console.WriteLine("Magic: " + mp + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 2);
            Console.WriteLine("Attack: " + attack + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 3);
            Console.WriteLine("Magic Attack: " + magicAttack + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 4);
            Console.WriteLine("Defense: " + defense + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 5);
            Console.WriteLine("Magic Defense: " + magicDefense + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 6);
            Console.WriteLine("Evade: " + evade + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 7);
            Console.WriteLine("Accuracy: " + accuracy + "   ");
            Console.SetCursorPosition(StatsX, StatsY + 8);
            Console.WriteLine("Range: " + range + "   ");
        }
    }
}