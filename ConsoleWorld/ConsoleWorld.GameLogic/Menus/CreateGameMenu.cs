using ConsoleWorld.Models;
using ConsoleWorld.Models.Classes;
using ConsoleWorld.Models.Enums;

namespace ConsoleWorld.GameLogic.Menus
{
    using System;
    public class CreateGameMenu
    {
        public string CharacterName { get; set; }
        public Class Character { get; set; }
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
        public void ChooseOption()
        {
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            Character = (Class)((int)(Character + 1) % 6);
                            if (Character == Class.Knight)
                            {
                                KnightChosen();
                            }
                            if (Character == Class.Viking)
                            {
                                VikingChosen();
                            }
                            if (Character == Class.Archer)
                            {
                                ArcherChosen();
                            }
                            if (Character == Class.Magician)
                            {
                                MagicianChosen();
                            }
                            if (Character == Class.Robot)
                            {
                                RobotChosen();
                            }
                            if (Character == Class.Thief)
                            {
                                ThiefChosen();
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            Character = this.Character - 1 < 0
                            ? Class.Thief
                            : (Class)(this.Character - 1);
                            if (Character == Class.Knight)
                            {
                                KnightChosen();
                            }
                            if (Character == Class.Viking)
                            {
                                VikingChosen();
                            }
                            if (Character == Class.Archer)
                            {
                                ArcherChosen();
                            }
                            if (Character == Class.Magician)
                            {
                                MagicianChosen();
                            }
                            if (Character == Class.Robot)
                            {
                                RobotChosen();
                            }
                            if (Character == Class.Thief)
                            {
                                ThiefChosen();
                            }
                        }
                        break;
                    
                }

                key = Console.ReadKey().Key;
            }
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
            Console.WriteLine("Health: " + int.Parse(Knight.DefaultHp.ToString()) + "   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Knight.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Knight.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Knight.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Knight.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Knight.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Knight.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Knight.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Knight.DefaultRange.ToString()) + "   ");
        }
        public void VikingChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Viking")
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
            Console.WriteLine("Health: " + int.Parse(Viking.DefaultHp.ToString()) + "   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Viking.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Viking.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Viking.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Viking.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Viking.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Viking.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Viking.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Viking.DefaultRange.ToString()) + "   ");
        }
        public void ArcherChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Archer")
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
            Console.WriteLine("Health: " + int.Parse(Archer.DefaultHp.ToString()) + "   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Archer.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Archer.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Archer.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Archer.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Archer.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Archer.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Archer.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Archer.DefaultRange.ToString()) + "   ");
        }
        public void MagicianChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Magician")
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
            Console.WriteLine("Health: " + int.Parse(Magician.DefaultHp.ToString()) + "   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Magician.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Magician.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Magician.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Magician.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Magician.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Magician.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Magician.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Magician.DefaultRange.ToString()) + "   ");
        }
        public void RobotChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Robot")
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
            Console.WriteLine("Health: " + int.Parse(Robot.DefaultHp.ToString()) + "   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Robot.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Robot.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Robot.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Robot.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Robot.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Robot.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Robot.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Robot.DefaultRange.ToString()) + "   ");
        }
        public void ThiefChosen()
        {
            int y = 18;
            foreach (var character in Enum.GetValues(typeof(Class)))
            {
                if (character.ToString() == "Thief")
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
            Console.WriteLine("Health: " + int.Parse(Thief.DefaultHp.ToString())+"   ");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine("Magic: " + int.Parse(Thief.DefaultMp.ToString()) + "   ");
            Console.SetCursorPosition(75, 19);
            Console.WriteLine("Attack: " + int.Parse(Thief.DefaultAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 20);
            Console.WriteLine("Magic Attack: " + int.Parse(Thief.DefaultMagicAttack.ToString()) + "   ");
            Console.SetCursorPosition(75, 21);
            Console.WriteLine("Defense: " + int.Parse(Thief.DefaultDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 22);
            Console.WriteLine("Magic Defense: " + int.Parse(Thief.DefaultMagicDefense.ToString()) + "   ");
            Console.SetCursorPosition(75, 23);
            Console.WriteLine("Evade: " + int.Parse(Thief.DefaultEvade.ToString()) + "   ");
            Console.SetCursorPosition(75, 24);
            Console.WriteLine("Accuracy: " + int.Parse(Thief.DefaultAccuracy.ToString()) + "   ");
            Console.SetCursorPosition(75, 25);
            Console.WriteLine("Range: " + int.Parse(Thief.DefaultRange.ToString()) + "   ");
        }
    }
}
