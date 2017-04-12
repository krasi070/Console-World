namespace ConsoleWorld.Models.Classes
{
    public class Magician : Character
    {
        private const int DefaultHp = 125;
        private const int DefaultMp = 100;
        private const int DefaultAttack = 10;
        private const int DefaultMagicAttack = 40;
        private const int DefaultDefense = 10;
        private const int DefaultMagicDefense = 30;
        private const int DefaultEvade = 5;
        private const int DefaultAccuracy = 82;
        private const int DefaultRange = 2;

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
        }
    }
}