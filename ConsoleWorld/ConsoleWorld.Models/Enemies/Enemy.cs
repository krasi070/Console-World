namespace ConsoleWorld.Models.Enemies
{
    using System;
    using System.Collections.Generic;

    public class Enemy : Unit
    {
        public Enemy()
        {
            this.IsVisible = false;
        }

        public int ExpReward { get; set; }

        public int Level { get; set; }

        public bool IsVisible { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public override void Draw()
        {
            if (this.IsVisible)
            {
                base.Draw();
            }
        }

        protected virtual void IncreaseStatsForLevel()
        {
            Random random = new Random();
            int pointsToGive = (this.Level - 1) * 2;
            for (int i = 0; i < pointsToGive; i++)
            {
                int amount = 1;
                if (random.Next(100) < 10)
                {
                    amount = 4;
                }

                int chance = random.Next(100);
                if (chance <= 12)
                {
                    this.Accuracy += amount;
                }
                else if (chance <= 24)
                {
                    this.MaxMp += amount;
                    this.Mp += amount;
                }
                else if (chance <= 36)
                {
                    this.Attack += amount;
                }
                else if (chance <= 48)
                {
                    this.MagicAttack += amount;
                }
                else if (chance <= 60)
                {
                    this.Defense += amount;
                }
                else if (chance <= 72)
                {
                    this.MagicDefense += amount;
                }
                else if (chance < 84)
                {
                    this.Evade += amount;
                }
                else if (chance < 100)
                {
                    this.MaxHp += amount;
                    this.Hp += amount;
                }
            }

            if (this.Level > 1)
            {
                this.ExpReward += (int)(this.ExpReward * this.Level * 0.5);
            }
        }
    }
}