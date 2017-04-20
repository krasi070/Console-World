namespace ConsoleWorld.Data
{
    using Models;
    using Models.Classes;
    using Models.Enemies;
    using Models.Enums;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;

    public class ConsoleWorldInitializer : DropCreateDatabaseAlways<ConsoleWorldContext>
    {
        protected override void Seed(ConsoleWorldContext context)
        {
            var enemies = new List<Enemy>()
            {
                new Rat(),
                new Bat(),
                new Zombie(),
                new Cyclops(),
                new Goblin()
            };

            context.Enemies.AddRange(enemies);

            var items = new List<Item>()
            {
                new Item("Health Potion (S)", 10, 25, ItemType.Hp),
                new Item("Health Potion (M)", 15, 50, ItemType.Hp),
                new Item("Health Potion (L)", 20, 75, ItemType.Hp),
                new Item("Health Potion (F)", 25, 100, ItemType.Hp),
                new Item("Magic Potion (S)", 15, 25, ItemType.Mp),
                new Item("Magic Potion (M)", 25, 50, ItemType.Mp),
                new Item("Magic Potion (L)", 40, 75, ItemType.Mp),
                new Item("Magic Potion (F)", 50, 100, ItemType.Mp),                
                new Item("Master Key", 100, 0, ItemType.Key),
                new Item("Normal Key", 5, 0, ItemType.Key)
            };

            context.Items.AddRange(items);

            var weapons = new List<Weapon>()
            {
                new Weapon("Sword", 20, 0, 50, 2),
                new Weapon("Wand", 1, 15, 60, 2),
                new Weapon("Katana", 30, 5, 80, 3),
                new Weapon("Stick", 5, 0, 15, 1),
                new Weapon("Hammer", 30, 0, 60, 3),
                new Weapon("Magic Bow", 10, 20, 80, 3)
            };

            context.Weapons.AddRange(weapons);

            var levels = new List<Level>()
            {
                new Level(100, 1),
                new Level(250, 1),
                new Level(600, 2),
                new Level(1000, 2),
                new Level(1750, 2)
            };

            context.Levels.AddRange(levels);
            this.SaveChanges(context);

            Character archer = new Thief()
            {
                Name = "Steve"
            };

            context.Characters.Add(archer);
            this.SaveChanges(context);

            context.CharacterItems.Add(new CharacterItem(1, 9, 1)); // 9 - Master Key
            this.SaveChanges(context);

            base.Seed(context);
        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(ConsoleWorldContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}