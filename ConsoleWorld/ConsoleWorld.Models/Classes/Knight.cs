namespace ConsoleWorld.Models.Classes
{
    public class Knight : Character
    {
        public const int DefaultHp = 250;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 50;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 25;
        public const int DefaultMagicDefense = 5;
        public const int DefaultEvade = 5;
        public const int DefaultAccuracy = 85;
        public const int DefaultRange = 1;

        public Knight()
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
        }
    }
}