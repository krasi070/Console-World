namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;

    public class Unit
    {
        private int hp;
        private int mp;

        [NotMapped]
        public int X { get; set; }

        [NotMapped]
        public int Y { get; set; }

        [NotMapped]
        public char Symbol { get; set; }

        [NotMapped]
        public ConsoleColor ForegroundColor { get; set; }

        [NotMapped]
        public ConsoleColor BackgroundColor { get; set; } 

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Money { get; set; }

        [Range(0, int.MaxValue)]
        public int MaxHp { get; set; }

        public int Hp
        {
            get
            {
                return this.hp;
            }

            set
            {
                if (value > this.MaxHp)
                {
                    value = this.MaxHp;
                }

                this.hp = value;
            }
        }

        [Range(0, int.MaxValue)]
        public int MaxMp { get; set; }

        [Range(0, int.MaxValue)]
        public int Mp
        {
            get
            {
                return this.mp;
            }

            set
            {
                if (value > this.MaxMp)
                {
                    value = this.MaxMp;
                }

                this.mp = value;
            }
        }

        [Range(0, int.MaxValue)]
        public int Attack { get; set; }

        [Range(0, int.MaxValue)]
        public int MagicAttack { get; set; }

        [Range(0, int.MaxValue)]
        public int Defense { get; set; }

        [Range(0, int.MaxValue)]
        public int MagicDefense { get; set; }

        [Range(0, 100)]
        public int Evade { get; set; }

        [Range(0, 100)]
        public int Accuracy { get; set; }

        [Range(0, int.MaxValue)]
        public int Range { get; set; }

        public virtual Weapon EquippedWeapon { get; set; }

        public virtual void Draw()
        {
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.ForegroundColor;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.Symbol);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}