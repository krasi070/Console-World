namespace ConsoleWorld.Models.Classes
{
    public class Magician : Character
    {
        public const int DefaultHp = 125;
        public const int DefaultMp = 100;
        public const int DefaultAttack = 10;
        public const int DefaultMagicAttack = 40;
        public const int DefaultDefense = 10;
        public const int DefaultMagicDefense = 30;
        public const int DefaultEvade = 5;
        public const int DefaultAccuracy = 82;
        public const int DefaultRange = 2;
        public const int DefaultLvl = 1;

        public const int DefaultPoints = 0;
        public const int DefaultExp = 0;
        public Magician()
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
            this.Class = Enums.Class.Magician;
            this.LevelId = DefaultLvl;

            this.Points = DefaultPoints;
            this.Exp = DefaultExp;
        }
    }
}