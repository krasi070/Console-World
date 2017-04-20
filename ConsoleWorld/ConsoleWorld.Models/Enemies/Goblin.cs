namespace ConsoleWorld.Models.Enemies
{
    using System;

    public class Goblin : Enemy
    {
        public const int DefaultHp = 120;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 25;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 10;
        public const int DefaultMagicDefense = 0;
        public const int DefaultEvade = 10;
        public const int DefaultAccuracy = 88;
        public const int DefaultRange = 1;
        public const int DefaultExpReward = 150;
        public const int DefaultMoneyReward = 8;
        public const char DefaultSymbol = 'g';
        public const string DefaultName = "Goblin";
        public const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor DefaultForegroundColor = ConsoleColor.Green;

        public Goblin()
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

        public Goblin(int level = 1)
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