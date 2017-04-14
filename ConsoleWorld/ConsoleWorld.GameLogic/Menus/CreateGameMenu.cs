using ConsoleWorld.Models;
using ConsoleWorld.Models.Classes;
using ConsoleWorld.Models.Enums;

namespace ConsoleWorld.GameLogic.Menus
{
    using System;
    public class CreateGameMenu
    {
        public string CharacterName { get; set; }
        public Character Character { get; set; }
        private const int length = 8;
        private string characterName;
        public void DrawCreateGameMenu()
        {
            bool characterIsValid = false;


            while (!characterIsValid)
            {
                Console.Clear();
                StartMenu.DrawTitle();
                Console.CursorVisible = true;
                Console.SetCursorPosition(20, 16);
                Console.Write("Character Name: ");
                this.characterName = Console.ReadLine();

                if (this.characterName.Length > 2 && this.characterName.Length < 10)
                {
                    if (true)
                    {
                        Console.CursorVisible = false;
                        // TODO: Check if character exist
                        characterIsValid = true;
                    }
                }
            }
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("Choose a class: ");
            KnightChosen();
        }

        public void KnightChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Knight")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(25, y);
                    Console.WriteLine(character);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    y += 1;
                }
                else
                {
                    Console.SetCursorPosition(25, y);
                    Console.WriteLine(character);
                    y += 1;
                }
            }
            Console.SetCursorPosition(75, 17);
            Console.WriteLine("Health:" + Knight.DefaultHp);
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic:" + Knight.DefaultMp);
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack:" + Knight.DefaultAttack);
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack:" + Knight.DefaultMagicAttack);
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense:" + Knight.DefaultDefense);
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense:" + Knight.DefaultMagicDefense);
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade:" + Knight.DefaultEvade);
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy:" + Knight.DefaultAccuracy);
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range:" + Knight.DefaultRange);
        }
    }
}
