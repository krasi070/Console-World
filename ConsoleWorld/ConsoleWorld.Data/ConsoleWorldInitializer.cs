namespace ConsoleWorld.Data
{
    using Models;
    using Models.Classes;
    using Models.Enums;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ConsoleWorldInitializer : DropCreateDatabaseAlways<ConsoleWorldContext>
    {
        protected override void Seed(ConsoleWorldContext context)
        {
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
                new Item("Attack Boost (S)", 20, 10, ItemType.Attack),
                new Item("Attack Boost (M)", 35, 20, ItemType.Attack),
                new Item("Attack Boost (L)", 55, 35, ItemType.Attack),
                new Item("Magic Attack Boost (S)", 20, 15, ItemType.MagicAttack),
                new Item("Magic Attack Boost (M)", 35, 25, ItemType.MagicAttack),
                new Item("Magic Attack Boost (L)", 60, 50, ItemType.MagicAttack),
                new Item("Defense Boost (S)", 10, 10, ItemType.Defense),
                new Item("Defense Boost (M)", 20, 25, ItemType.Defense),
                new Item("Defense Boost (L)", 35, 50, ItemType.Defense),
                new Item("Magic Defense Boost (S)", 15, 25, ItemType.MagicDefense),
                new Item("Magic Defense Boost (M)", 25, 50, ItemType.MagicDefense),
                new Item("Magic Defense Boost (L)", 35, 75, ItemType.MagicDefense),
                new Item("Evasion Boost (S)", 15, 5, ItemType.Evade),
                new Item("Evasion Boost (M)", 25, 10, ItemType.Evade),
                new Item("Evasion Boost (L)", 35, 15, ItemType.Evade),
                new Item("Accuracy Boost (S)", 10, 5, ItemType.Accuracy),
                new Item("Accuracy Boost (M)", 15, 10, ItemType.Accuracy),
                new Item("Accuracy Boost (L)", 20, 15, ItemType.Accuracy),
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
            context.SaveChanges();

            Character archer = new Thief()
            {
                Name = "Steve"
            };

            context.Characters.Add(archer);
            context.SaveChanges();

            context.CharacterItems.Add(new CharacterItem(1, 27, 1)); // 27 - Master Key
            context.SaveChanges();

            base.Seed(context);
        }
    }
}