namespace ConsoleWorld.Models.Classes
{
    public class Robot : Character
    {
        public const int DefaultHp = 200;
        public const int DefaultMp = 50;
        public const int DefaultAttack = 25;
        public const int DefaultMagicAttack = 31;
        public const int DefaultDefense = 25;
        public const int DefaultMagicDefense = 25;
        public const int DefaultEvade = 5;
        public const int DefaultAccuracy = 80;
        public const int DefaultRange = 1;
        public const int DefaultLvl = 1;

        public const int DefaultPoints = 0;
        public const int DefaultExp = 0;
        public Robot()
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
            this.Class = Enums.Class.Robot;
            this.LevelId = DefaultLvl;

            this.Points = DefaultPoints;
            this.Exp = DefaultExp;
        }
    }
}