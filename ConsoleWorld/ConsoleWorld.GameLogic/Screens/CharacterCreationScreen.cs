namespace ConsoleWorld.GameLogic.Screens
{
    using Models.Enums;
    using System;

    public static class CharacterCreationScreen
    {
        private const int SelectLength = 12;
        private const int TextX = 20;
        private const int TextY = 16;
        private const int MinNameLength = 2;
        private const int MaxNameLength = 10;
        private const int NumberOfClasses = 6;
        private const int ClassesX = 25;
        private const int ClassesY = 18;
        private const int StatsX = 75;
        private const int StatsY= 17;

        public static string CharacterName { get; set; }

        public static Class Class { get; set; }

        public static void Draw()
        {
            Console.Clear();
            TitleScreen.DrawTitle();
        }

        public static void CreateCharacter()
        {
            NameCharacter();
            SelectClass();
        }

        private static void SelectClass()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            Class = (Class)((int)(Class + 1) % NumberOfClasses);
                            HighlightClass();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            Class = Class - 1 < 0
                            ? Class.Thief
                            : (Class)(Class - 1);
                            HighlightClass();
                        }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }
        }

        private static void HighlightClass()
        {
            if (Class == Class.Knight)
            {
                KnightChosen();
            }
            else if (Class == Class.Viking)
            {
                VikingChosen();
            }
            else if (Class == Class.Archer)
            {
                ArcherChosen();
            }
            else if (Class == Class.Magician)
            {
                MagicianChosen();
            }
            else if (Class == Class.Robot)
            {
                RobotChosen();
            }
            else if (Class == Class.Thief)
            {
                ThiefChosen();
            }
        }

        private static void NameCharacter()
        {
            bool characterIsValid = false;

            while (!characterIsValid)
            {
                Console.CursorVisible = true;
                Console.SetCursorPosition(TextX, TextY);
                Console.Write("Character Name: ");
                CharacterName = Console.ReadLine();

                if (CharacterName.Length > MinNameLength && CharacterName.Length < MaxNameLength)
                {
                    if (true)
                    {
                        // TODO: Check if character exist
                        characterIsValid = true;
                    }
                }
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(TextX, TextY + 1);
            Console.WriteLine("Choose a class: ");
            KnightChosen();
        }

        private static void KnightChosen()
        {
            DrawClass("Knight");
            DrawStats("Knight");
        }

        private static void VikingChosen()
        {
            DrawClass("Viking");
            DrawStats("Viking");
        }

        private static void ArcherChosen()
        {
            DrawClass("Archer");
            DrawStats("Archer");
        }

        private static void MagicianChosen()
        {
            DrawClass("Magician");
            DrawStats("Magician");
        }

        private static void RobotChosen()
        {
            DrawClass("Robot");
            DrawStats("Robot");
        }

        private static void ThiefChosen()
        {
            DrawClass("Thief");
            DrawStats("Thief");
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
                    Console.WriteLine(character);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.SetCursorPosition(ClassesX, ClassesY + i);
                    Console.WriteLine(character);
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
