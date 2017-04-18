namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using ConsoleWorld.Data;
    using Models;

    public static class LoadGameScreen
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 10;
        private const int NameX = 45;
        private const int NameY = 15;
        private const int EnterCode = 13;
        private const int BackspaceCode = 8;

        private static string characterName;

        public static void Draw()
        {
            Console.Clear();
            TitleScreen.DrawTitle();
            Console.SetCursorPosition(NameX, NameY + 1);
            Console.WriteLine("Character: ");
        }

        public static Character GetCharacter()
        {
            while (true)
            {
                Console.SetCursorPosition(NameX + 11, NameY + 1);
                Console.Write(new string(' ', MaxNameLength));
                characterName = GetName();
                bool exists = Utility.CheckIfCharacterExists(characterName);

                if (exists)
                {
                    Console.SetCursorPosition(NameX, NameY);
                    Console.Write("Loading...                    ");

                    return Utility.GetCharacterByName(characterName);
                }
                else
                {
                    Console.SetCursorPosition(NameX, NameY);
                    Console.Write("This character does not exist!");
                }
            }
        }
        
        private static string GetName()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(NameX + 11, NameY + 1);
            string name = string.Empty;
            char letter = Console.ReadKey(true).KeyChar;

            while (letter != EnterCode || name.Length < MinNameLength)
            {
                if (name.Length >= MaxNameLength && letter != BackspaceCode)
                {
                    letter = Console.ReadKey(true).KeyChar;
                    continue;
                }

                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') || (letter >= '0' && letter <= '9'))
                {
                    name += letter.ToString();
                }
                else if (letter == BackspaceCode && name.Length > 0)
                {
                    name = name.Substring(0, name.Length - 1);
                }

                Console.SetCursorPosition(NameX + 11, NameY + 1);
                for (int i = 0; i < MaxNameLength ; i++)
                {
                    if (i >= name.Length)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(name[i]);
                    }
                }

                Console.SetCursorPosition(NameX + 11 + name.Length, NameY + 1);
                letter = Console.ReadKey(true).KeyChar;
            }

            Console.CursorVisible = false;

            return name;
        }
    }
}