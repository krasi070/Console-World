namespace ConsoleWorld.Models.Classes
{
    public class Thief : Character
    {
        public const int DefaultHp = 160;
        public const int DefaultMp = 0;
        public const int DefaultAttack = 35;
        public const int DefaultMagicAttack = 0;
        public const int DefaultDefense = 12;
        public const int DefaultMagicDefense = 15;
        public const int DefaultEvade = 30;
        public const int DefaultAccuracy = 90;
        public const int DefaultRange = 1;
        public const int DefaultLvl = 1;

        public const int DefaultPoints = 0;
        public const int DefaultExp = 0;
        public Thief()
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
            this.Class = Enums.Class.Thief;
            this.LevelId = DefaultLvl;

            this.Points = DefaultPoints;
            this.Exp = DefaultExp;
        }
    }
}