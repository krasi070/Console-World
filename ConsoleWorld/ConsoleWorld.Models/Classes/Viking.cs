namespace ConsoleWorld.Models.Classes
{
    public class Viking : Character
    {
        private const int DefaultHp = 220;
        private const int DefaultMp = 0;
        private const int DefaultAttack = 65;
        private const int DefaultMagicAttack = 0;
        private const int DefaultDefense = 18;
        private const int DefaultMagicDefense = 10;
        private const int DefaultEvade = 7;
        private const int DefaultAccuracy = 80;
        private const int DefaultRange = 1;

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