namespace ConsoleWorld.Models.Classes
{
    public class Archer : Character
    {
        private const int DefaultHp = 150;
        private const int DefaultMp = 0;
        private const int DefaultAttack = 35;
        private const int DefaultMagicAttack = 0;
        private const int DefaultDefense = 13;
        private const int DefaultMagicDefense = 8;
        private const int DefaultEvade = 20;
        private const int DefaultAccuracy = 75;
        private const int DefaultRange = 3;

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