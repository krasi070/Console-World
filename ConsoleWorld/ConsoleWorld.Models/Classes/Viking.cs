namespace ConsoleWorld.Models.Classes
{
    public class Viking : Character
    {
        public const int DefaultHp = 220;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 65;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 18;
        public const int DefaultMagicDefense = 10;
        public const int DefaultEvade = 7;
        public const int DefaultAccuracy = 80;
        public const int DefaultRange = 1;

        public Viking()
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