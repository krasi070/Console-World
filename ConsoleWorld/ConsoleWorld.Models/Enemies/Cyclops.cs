namespace ConsoleWorld.Models.Enemies
{
    using System;

    public class Cyclops : Enemy
    {
        public const int DefaultHp = 150;
        public const int DefaultMp = 30;
        public const int DefaultAttack = 25;
        public const int DefaultMagicAttack = 30;
        public const int DefaultDefense = 20;
        public const int DefaultMagicDefense = 10;
        public const int DefaultEvade = 0;
        public const int DefaultAccuracy = 80;
        public const int DefaultRange = 1;
        public const int DefaultExpReward = 200;
        public const int DefaultMoneyReward = 11;
        public const char DefaultSymbol = 'c';
        public const string DefaultName = "Cyclops";
        public const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor DefaultForegroundColor = ConsoleColor.DarkYellow;

        public Cyclops()
            : base()
        {
            this.MaxHp = DefaultHp;
            this.Hp = DefaultHp;
            this.MaxMp = DefaultMp;
            this.Mp = DefaultMp;
            this.Attack = DefaultAttack;
            this.MagicAttack = DefaultMagicAttack;
            this.Defense = DefaultDefense;
            this.MagicDefense = DefaultMagicDefense;
            this.Evade = DefaultEvade;
            this.Accuracy = DefaultAccuracy;
            this.Range = DefaultRange;
            this.ExpReward = DefaultExpReward;
            this.Money = DefaultMoneyReward;
            this.Symbol = DefaultSymbol;
            this.Name = DefaultName;
            this.BackgroundColor = DefaultBackgroundColor;
            this.ForegroundColor = DefaultForegroundColor;
        }

        public Cyclops(int level = 1)
            : base()
        {
            this.Level = level;
            this.MaxHp = DefaultHp;
            this.Hp = DefaultHp;
            this.MaxMp = DefaultMp;
            this.Mp = DefaultMp;
            this.Attack = DefaultAttack;
            this.MagicAttack = DefaultMagicAttack;
            this.Defense = DefaultDefense;
            this.MagicDefense = DefaultMagicDefense;
            this.Evade = DefaultEvade;
            this.Accuracy = DefaultAccuracy;
            this.Range = DefaultRange;
            this.ExpReward = DefaultExpReward;
            this.Symbol = DefaultSymbol;
            this.Name = DefaultName;
            this.BackgroundColor = DefaultBackgroundColor;
            this.ForegroundColor = DefaultForegroundColor;
            this.IncreaseStatsForLevel();
        }
    }
}