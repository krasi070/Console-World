namespace ConsoleWorld.Models.Classes
{
    public class Robot : Character
    {
        private const int DefaultHp = 200;
        private const int DefaultMp = 50;
        private const int DefaultAttack = 25;
        private const int DefaultMagicAttack = 31;
        private const int DefaultDefense = 25;
        private const int DefaultMagicDefense = 25;
        private const int DefaultEvade = 5;
        private const int DefaultAccuracy = 80;
        private const int DefaultRange = 1;

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
        }
    }
}