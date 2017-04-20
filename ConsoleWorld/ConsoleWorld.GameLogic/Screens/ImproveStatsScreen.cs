using ConsoleWorld.GameLogic.Core;

namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using Enums;
    using Models;
    using Data;
    using Models.Classes;

    public class ImproveStatsScreen
    {
        private const int TitleX = 29;
        private const int TitleY = 0;
        private const int OptionsX = 30;
        private const int OptionsY = 10;
        private const int SelectLength = 17;
        private const int NumberOfOptions = 9;
        private const int StatsX = 70;
        private const int StatsY = 14;
        private const int PointsX = 70;
        private const int PointsY = 10;


        public static ImproveStatsOption CurrentOption { get; set; }

        public static Character CurrentClass { get; set; }

        //public static Character CurrentClass = new Archer()
        //{
        //    Name = "asdgfasd"
        //};

       
        public static void Draw(Character character)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 2);
            Console.WriteLine("Using the points you've obtained you can improve your stats.");

            HighlightOption(ImproveStatsOption.MaxHp,character);
            RemoveHighlight(ImproveStatsOption.MaxMp);
            RemoveHighlight(ImproveStatsOption.Attack);
            RemoveHighlight(ImproveStatsOption.MagicAttack);
            RemoveHighlight(ImproveStatsOption.Defense);
            RemoveHighlight(ImproveStatsOption.MagicDefense);
            RemoveHighlight(ImproveStatsOption.Evade);
            RemoveHighlight(ImproveStatsOption.Accuracy);
            RemoveHighlight(ImproveStatsOption.Back);
        }

        public static bool SelectOption(Character character)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            RemoveHighlight(CurrentOption);
                            CurrentOption = (ImproveStatsOption)((int)(CurrentOption + 1) % NumberOfOptions);
                            HighlightOption(CurrentOption,character);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                             RemoveHighlight(CurrentOption);
                            CurrentOption = CurrentOption - 1 < 0
                             ? ImproveStatsOption.Back
                            : (ImproveStatsOption)(CurrentOption - 1);
                             HighlightOption(CurrentOption,character);
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            var ctx = new ConsoleWorldContext();
                            if (character.Points <= 0 && CurrentOption.ToString()!="Back")
                            {
                                Console.SetCursorPosition(40, 5);
                                Console.WriteLine("You don't have enough points for that!");
                                key = Console.ReadKey(true).Key;

                                continue;
                            }
                            switch (CurrentOption.ToString())
                            {
                                case "MaxHp":
                                    character.MaxHp += 1;
                                    character.Points--;
                                    DrawStats(character, "MaxHp");
                                    break;
                                case "MaxMp":
                                    character.MaxMp += 1;
                                    character.Points--;
                                    DrawStats(character, "MaxMp");

                                    break;
                                case "Attack":
                                    character.Attack += 1;
                                    character.Points--;
                                    DrawStats(character, "Attack");

                                    break;
                                case "MagicAttack":
                                    character.MagicAttack += 1;
                                    character.Points--;
                                    DrawStats(character, "MagicAttack");

                                    break;
                                case "Defense":
                                    character.Defense += 1;
                                    character.Points--;
                                    DrawStats(character, "Defense");

                                    break;
                                case "MagicDefense":
                                    character.MagicDefense += 1;
                                    character.Points--;
                                    DrawStats(character, "MagicDefense");

                                    break;
                                case "Accuracy":
                                    character.Accuracy += 1;
                                    character.Points--;
                                    DrawStats(character, "Accuracy");

                                    break;
                                case "Evade":
                                    character.Evade += 1;
                                    character.Points--;
                                    DrawStats(character, "Evaded");

                                    break;
                                case "Back":
                                   
                                    return true;
                            }
                            ctx.SaveChanges();
                                                           
                            
                        }
                        break;

                }
                Console.SetCursorPosition(40, 5);
                Console.WriteLine(new string(' ', "You don't have enough points for that!".Length));
                key = Console.ReadKey(true).Key;
            }
            return false;
        }

        private static void HighlightOption(ImproveStatsOption option,Character character)
        {
            if (option == ImproveStatsOption.MaxHp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Max Health".Length) / 2) + "Max Health" + new string(' ', (SelectLength - "Max Health".Length) / 2 + (SelectLength - "Max Health".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "MaxHp");
            }

            if (option == ImproveStatsOption.MaxMp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Max Magic Power".Length) / 2) + "Max Magic Power" + new string(' ', (SelectLength - "Max Magic Power".Length) / 2 + (SelectLength - "Max Magic Power".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "MaxMp");

            }

            if (option == ImproveStatsOption.Attack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Attack".Length) / 2) + "Attack" + new string(' ', (SelectLength - "Attack".Length) / 2 + (SelectLength - "Attack".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "Attack");

            }

            if (option == ImproveStatsOption.MagicAttack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Magic Attack".Length) / 2) + "Magic Attack" + new string(' ', (SelectLength - "Magic Attack".Length) / 2 + (SelectLength - "Magic Attack".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "MagicAttack");

            }
            if (option == ImproveStatsOption.Defense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 4);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Defense".Length) / 2) + "Defense" + new string(' ', (SelectLength - "Defense".Length) / 2 + (SelectLength - "Defense".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "Defense");

            }
            if (option == ImproveStatsOption.MagicDefense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 5);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Magic Defense".Length) / 2) + "Magic Defense" + new string(' ', (SelectLength - "Magic Defense".Length) / 2 + (SelectLength - "Magic Defense".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "MagicDefense");

            }
            if (option == ImproveStatsOption.Evade)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 6);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Evade".Length) / 2) + "Evade" + new string(' ', (SelectLength - "Evade".Length) / 2 + (SelectLength - "Evade".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "Evade");

            }
            if (option == ImproveStatsOption.Accuracy)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 7);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Accuracy".Length) / 2) + "Accuracy" + new string(' ', (SelectLength - "Accuracy".Length) / 2 + (SelectLength - "Accuracy".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(character, "Accuracy");

            }
            if (option == ImproveStatsOption.Back)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 8);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.SetCursorPosition(StatsX, StatsY);
                Console.Write(new string(' ', 40));
            }
        }

        private static void RemoveHighlight(ImproveStatsOption option)
        {
            if (option == ImproveStatsOption.MaxHp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.WriteLine(new string(' ', (SelectLength - "Max Health".Length) / 2) + "Max Health" + new string(' ', (SelectLength - "Max Health".Length) / 2 + (SelectLength - "Max Health".Length) % 2));
            }

            if (option == ImproveStatsOption.MaxMp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.WriteLine(new string(' ', (SelectLength - "Max Magic Power".Length) / 2) + "Max Magic Power" + new string(' ', (SelectLength - "Max Magic Power".Length) / 2 + (SelectLength - "Max Magic Power".Length) % 2));
            }

            if (option == ImproveStatsOption.Attack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.WriteLine(new string(' ', (SelectLength - "Attack".Length) / 2) + "Attack" + new string(' ', (SelectLength - "Attack".Length) / 2 + (SelectLength - "Attack".Length) % 2));
            }

            if (option == ImproveStatsOption.MagicAttack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Magic Attack".Length) / 2) + "Magic Attack" + new string(' ', (SelectLength - "Magic Attack".Length) / 2 + (SelectLength - "Magic Attack".Length) % 2));
            }

            if (option == ImproveStatsOption.Evade)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 6);
                Console.WriteLine(new string(' ', (SelectLength - "Evade".Length) / 2) + "Evade" + new string(' ', (SelectLength - "Evade".Length) / 2 + (SelectLength - "Evade".Length) % 2));
            }

            if (option == ImproveStatsOption.Defense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 4);
                Console.WriteLine(new string(' ', (SelectLength - "Defense".Length) / 2) + "Defense" + new string(' ', (SelectLength - "Defense".Length) / 2 + (SelectLength - "Defense".Length) % 2));
            }

            if (option == ImproveStatsOption.MagicDefense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 5);
                Console.WriteLine(new string(' ', (SelectLength - "Magic Defense".Length) / 2) + "Magic Defense" + new string(' ', (SelectLength - "Magic Defense".Length) / 2 + (SelectLength - "Magic Defense".Length) % 2));
            }

            if (option == ImproveStatsOption.Accuracy)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 7);
                Console.WriteLine(new string(' ', (SelectLength - "Accuracy".Length) / 2) + "Accuracy" + new string(' ', (SelectLength - "Accuracy".Length) / 2 + (SelectLength - "Accuracy".Length) % 2));
            }
            if (option == ImproveStatsOption.Back)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 8);
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
            }
        }

        private static void DrawStats(Character ch,string stat)
        {
            // Console.WriteLine(stat);
            string className = ch.Class.ToString();
            Type type = Type.GetType($"ConsoleWorld.Models.Classes.{className},ConsoleWorld.Models");
            string curr = type.GetProperty(stat).GetValue(ch).ToString();            
            Console.SetCursorPosition(StatsX, StatsY);
            Console.Write(new string(' ',40));
            Console.SetCursorPosition(StatsX, StatsY);
            Console.Write($"Current {stat}: {curr}");
            PrintPoints(ch);
            
        }
        private static void PrintPoints(Character character)
        {
            Console.SetCursorPosition(PointsX, PointsY);
            Console.Write(new string(' ', 40));
            Console.SetCursorPosition(PointsX, PointsY);
            Console.Write($"Your points: {character.Points}");
        }
    }
}