namespace ConsoleWorld.GameLogic.Screens
{
    using System;
    using Enums;
    using Models;
    using Data;

    public class ImproveStatsScreen
    {
        private const int TitleX = 29;
        private const int TitleY = 0;
        private const int OptionsX = 52;
        private const int OptionsY = 20;
        private const int SelectLength = 16;
        private const int NumberOfOptions = 8;
        private const int StatsX = 75;
        private const int StatsY = 17;

        public static ImproveStatsOption CurrentOption { get; set; }
        public static Character CurrentClass { get; set; }
        //TODO: GET THE CURRENT CLASS

        public static void Draw()
        {
            Console.Clear();
            TitleScreen.Draw();
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("Using the points you've obtained you can improve your stats.");

            HighlightOption(ImproveStatsOption.MaxHp);
            RemoveHighlight(ImproveStatsOption.MaxMp);
            RemoveHighlight(ImproveStatsOption.Attack);
            RemoveHighlight(ImproveStatsOption.MagicAttack);
            RemoveHighlight(ImproveStatsOption.Defense);
            RemoveHighlight(ImproveStatsOption.MagicDefense);
            RemoveHighlight(ImproveStatsOption.Evade);
            RemoveHighlight(ImproveStatsOption.Accuracy);

        }

        public static void SelectOption()
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
                            HighlightOption(CurrentOption);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                             RemoveHighlight(CurrentOption);
                            CurrentOption = CurrentOption - 1 < 0
                             ? ImproveStatsOption.Back
                            : (ImproveStatsOption)(CurrentOption - 1);
                             HighlightOption(CurrentOption);
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            //TODO: Improve the stat in the database
                            var ctx = new ConsoleWorldContext();
                            
                            if (CurrentOption == ImproveStatsOption.Back)
                            {
                                //TODO: Return to the game
                            }
                        }
                        break;
                }

                key = Console.ReadKey(true).Key;
            }
        }

        private static void HighlightOption(ImproveStatsOption option)
        {
            if (option == ImproveStatsOption.MaxHp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Max Health".Length) / 2) + "Max Health" + new string(' ', (SelectLength - "Max Health".Length) / 2 + (SelectLength - "Max Health".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(),"MaxHp");
            }

            if (option == ImproveStatsOption.MaxMp)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Max Magic Power".Length) / 2) + "Max Magic Power" + new string(' ', (SelectLength - "Max Magic Power".Length) / 2 + (SelectLength - "Max Magic Power".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "MaxMp");

            }

            if (option == ImproveStatsOption.Attack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Attack".Length) / 2) + "Attack" + new string(' ', (SelectLength - "Attack".Length) / 2 + (SelectLength - "Attack".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "Attack");

            }

            if (option == ImproveStatsOption.MagicAttack)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Magic Attack".Length) / 2) + "Magic Attack" + new string(' ', (SelectLength - "Magic Attack".Length) / 2 + (SelectLength - "Magic Attack".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "MagicAttack");

            }
            if (option == ImproveStatsOption.Defense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Defense".Length) / 2) + "Defense" + new string(' ', (SelectLength - "Defense".Length) / 2 + (SelectLength - "Defense".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "Defense");

            }
            if (option == ImproveStatsOption.MagicDefense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Magic Defense".Length) / 2) + "Magic Defense" + new string(' ', (SelectLength - "Magic Defense".Length) / 2 + (SelectLength - "Magic Defense".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "MagicDefense");

            }
            if (option == ImproveStatsOption.Evade)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Evade".Length) / 2) + "Evade" + new string(' ', (SelectLength - "Evade".Length) / 2 + (SelectLength - "Evade".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "Evade");

            }
            if (option == ImproveStatsOption.Accuracy)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Accuracy".Length) / 2) + "Accuracy" + new string(' ', (SelectLength - "Accuracy".Length) / 2 + (SelectLength - "Accuracy".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                DrawStats(CurrentClass.Class.ToString(), "Accuracy");

            }
            if (option == ImproveStatsOption.Back)
            {
                Console.SetCursorPosition(OptionsX, OptionsY);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Evade".Length) / 2) + "Evade" + new string(' ', (SelectLength - "Evade".Length) / 2 + (SelectLength - "Evade".Length) % 2));
            }

            if (option == ImproveStatsOption.Defense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Defense".Length) / 2) + "Defense" + new string(' ', (SelectLength - "Defense".Length) / 2 + (SelectLength - "Defense".Length) % 2));
            }

            if (option == ImproveStatsOption.MagicDefense)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Magic Defense".Length) / 2) + "Magic Defense" + new string(' ', (SelectLength - "Magic Defense".Length) / 2 + (SelectLength - "Magic Defense".Length) % 2));
            }

            if (option == ImproveStatsOption.Accuracy)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Accuracy".Length) / 2) + "Accuracy" + new string(' ', (SelectLength - "Accuracy".Length) / 2 + (SelectLength - "Accuracy".Length) % 2));
            }
            if (option == ImproveStatsOption.Back)
            {
                Console.SetCursorPosition(OptionsX, OptionsY + 3);
                Console.WriteLine(new string(' ', (SelectLength - "Back".Length) / 2) + "Back" + new string(' ', (SelectLength - "Back".Length) / 2 + (SelectLength - "Back".Length) % 2));
            }
        }

        private static void DrawStats(string className,string stat)
        {
            Type type = Type.GetType($"ConsoleWorld.Models.Classes.{className},ConsoleWorld.Models");
            string curr = type.GetField(stat).GetValue(null).ToString();
            Console.SetCursorPosition(StatsX, StatsY);
            Console.WriteLine($"Current {stat}: {curr}");
        }
    }
}