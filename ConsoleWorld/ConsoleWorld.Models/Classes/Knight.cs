namespace ConsoleWorld.Models.Classes
{
    public class Knight : Character
    {
        private const int DefaultHp = 250;
        private const int DefaultMp = 0;
        private const int DefaultAttack = 50;
        private const int DefaultMagicAttack = 0;
        private const int DefaultDefense = 25;
        private const int DefaultMagicDefense = 5;
        private const int DefaultEvade = 5;
        private const int DefaultAccuracy = 85;
        private const int DefaultRange = 1;

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