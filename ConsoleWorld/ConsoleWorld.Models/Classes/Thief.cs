namespace ConsoleWorld.Models.Classes
{
    public class Thief : Character
    {
        private const int DefaultHp = 160;
        private const int DefaultMp = 0;
        private const int DefaultAttack = 35;
        private const int DefaultMagicAttack = 0;
        private const int DefaultDefense = 12;
        private const int DefaultMagicDefense = 15;
        private const int DefaultEvade = 30;
        private const int DefaultAccuracy = 90;
        private const int DefaultRange = 1;

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
        }
    }
}