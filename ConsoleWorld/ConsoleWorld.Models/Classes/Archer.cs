namespace ConsoleWorld.Models.Classes
{
    public class Archer : Character
    {
        public const int DefaultHp = 150;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 35;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 13;
        public const int DefaultMagicDefense = 8;
        public const int DefaultEvade = 20;
        public const int DefaultAccuracy = 75;
        public const int DefaultRange = 3;

        public Archer()
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