namespace ConsoleWorld.Models.Enemies
{
    using System;

    public class Zombie : Enemy
    {
        public const int DefaultHp = 100;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 30;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 0;
        public const int DefaultMagicDefense = 0;
        public const int DefaultEvade = 2;
        public const int DefaultAccuracy = 90;
        public const int DefaultRange = 1;
        public const int DefaultExpReward = 100;
        public const int DefaultMoneyReward = 7;
        public const char DefaultSymbol = 'z';
        public const string DefaultName = "Zombie";
        public const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        public const ConsoleColor DefaultForegroundColor = ConsoleColor.DarkGreen;

        public Zombie()
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

        public Zombie(int level = 1)
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