namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using ConsoleWorld.Data;
    public class LoadGameScreen
    {
        private static string characterName;
        private const int MinNameLength = 2;
        private const int MaxNameLength = 10;
        private static bool alreadyExists = false;
        public static void Draw()
        {
            while (true)
            {
                Console.Clear();
                TitleScreen.DrawTitle();
                if (alreadyExists)
                {
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("This character name does not exist!");
                }
                Console.SetCursorPosition(45, 16);
                Console.WriteLine("Username: ");
                characterName = GetName();
                var check = Utility.CheckCharacterNameInDB(characterName);
                
                if (check)
                {
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("Bravo");
                    break;
                }
                else
                {
                    alreadyExists = true;
                    Draw();
                }     
            }
        }
        
        private static string GetName()
        {
            string name = string.Empty;
            char letter = Console.ReadKey(true).KeyChar;

            while (letter != 13 || name.Length < MinNameLength)
            {
                if (name.Length >= MaxNameLength && letter != 8)
                {
                    letter = Console.ReadKey(true).KeyChar;
                    continue;
                }

                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') || (letter >= '0' && letter <= '9'))
                {
                    name += letter.ToString();
                }
                else if (letter == 8 && name.Length > 0)
                {
                    name = name.Substring(0, name.Length - 1);
                }

                Console.SetCursorPosition(55, 16);
                for (int i = 0; i <MaxNameLength ; i++)
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

                letter = Console.ReadKey(true).KeyChar;
            }

            return name;
        }
    }
}
