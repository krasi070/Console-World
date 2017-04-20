namespace ConsoleWorld.Data
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models.Enums;
    using Models.Classes;
    using Models.Enemies;

    public static class Utility
    {
        private const int MaxAmountOfItemsFromMagicWell = 3;

        private static Random random = new Random();

        public static void InitDb()
        {
            var context = new ConsoleWorldContext();
            context.Database.Initialize(true);
        }

        public static Character CreateNewCharacter(Class characterClass, string name)
        {
            var character = new Character();
            using (var context = new ConsoleWorldContext())
            {
                if (characterClass.ToString() == "Archer")
                {
                    character = new Archer();
                }
                else if (characterClass.ToString() == "Knight")
                {
                    character = new Knight();
                }
                else if (characterClass.ToString() == "Magician")
                {
                    character = new Magician();
                }
                else if (characterClass.ToString() == "Robot")
                {
                    character = new Robot();
                }
                else if (characterClass.ToString() == "Thief")
                {
                    character = new Thief();
                }
                else if (characterClass.ToString() == "Viking")
                {
                    character = new Viking();
                }

                character.Name = name;
                context.Characters.Add(character);
                context.SaveChanges();

                var id = context.Characters.FirstOrDefault(c => c.Name == name).Id;
                context.CharacterItems.Add(new CharacterItem(id, 10, 10)); // 28 - normal key
                context.SaveChanges();
            }

            return character;
        }

        public static bool CheckIfCharacterExists(string name)
        {
            bool exists = false;
            using (var context = new ConsoleWorldContext())
            {
                if (context.Characters.Any(c => c.Name == name))
                {
                    exists = true;
                }
            }
            
            return exists;
        }

        public static Character GetCharacterByName(string name)
        {
            Character character = null;
            using (var context = new ConsoleWorldContext())
            {
                character = context.Characters.FirstOrDefault(c => c.Name == name);
            }

            return character;
        }

        public static bool CheckIfCharacterHasItem(int characterId, string itemName)
        {
            bool hasItem = false;
            using (var context = new ConsoleWorldContext())
            {
                var item = context.Items.FirstOrDefault(i => i.Name == itemName);
                if (item != null)
                {
                    var characterItem = context.CharacterItems.FirstOrDefault(ci => ci.CharacterId == characterId && ci.ItemId == item.Id);
                    if (characterItem != null)
                    {
                        hasItem = characterItem.Quantity > 0;
                    }
                }
            }

            return hasItem;
        }

        public static void RemoveOneItemFromCharacter(int characterId, int itemId)
        {
            using (var context = new ConsoleWorldContext())
            {
                var characterItem = context.CharacterItems.FirstOrDefault(ci => ci.ItemId == itemId && ci.CharacterId == characterId);
                if (characterItem != null)
                {
                    characterItem.Quantity--;
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveOneItemFromCharacter(int characterId, string itemName)
        {
            using (var context = new ConsoleWorldContext())
            {
                var item = context.Items.FirstOrDefault(i => i.Name == itemName);
                if (item != null)
                {
                    var characterItem = context.CharacterItems.FirstOrDefault(ci => ci.ItemId == item.Id && ci.CharacterId == characterId);
                    if (characterItem != null)
                    {
                        characterItem.Quantity--;
                        context.SaveChanges();
                    }
                }
            }
        }

        public static Dictionary<string,int> GetCharacterItems(int characterId)

        {
            using (var context = new ConsoleWorldContext())
            {
                List<CharacterItem> items = context.CharacterItems.Where(ci => ci.CharacterId == characterId).ToList();

                Dictionary<string,int> dictionary= new Dictionary<string, int>();
                foreach (var item in items)
                {
                    dictionary.Add(item.Item.Name,item.Quantity);
                }
                dictionary.Add("Back",-1);
                return dictionary;
            }
        }

        public static List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            using (var context = new ConsoleWorldContext())
            {
                items.AddRange(context.Items.ToList());
            }

            return items;
        }

        public static List<Item> GetCharactersItems(int characterId)
        {
            List<Item> items = new List<Item>();
            using (var context = new ConsoleWorldContext())
            {

            }

            return items;
        }

        public static void AddItemToCharacter(int characterId, int itemId)
        {
            using (var context = new ConsoleWorldContext())
            {
                if (context.Characters.Any(c => c.Id == characterId) && context.Items.Any(i => i.Id == itemId))
                {
                    var characterItem = context.CharacterItems.FirstOrDefault(ci => ci.CharacterId == characterId && ci.ItemId == itemId);
                    if (characterItem != null)
                    {
                        characterItem.Quantity++;
                    }
                    else
                    {
                        context.CharacterItems.Add(new CharacterItem(characterId, itemId, 1));
                    }

                    context.SaveChanges();
                }
            }
        }

        public static void IncreaseCharacterLevel(int characterId, int additionalExp)
        {
            using (var context = new ConsoleWorldContext())
            {
                var character = context.Characters.FirstOrDefault(c => c.Id == characterId);
                if (character != null && context.Levels.Count() > character.LevelId)
                {
                    int newLevel = character.LevelId + 1;
                    character.LevelId++;
                    character.Level = context.Levels.FirstOrDefault(l => l.LevelId == newLevel);
                    character.Points += character.Level.PointsToReceive;
                    character.Exp = additionalExp;
                }

                context.SaveChanges();
            }
        }

        public static int GetExpToNextLevel(int characterId)
        {
            int exp = 0;
            using (var context = new ConsoleWorldContext())
            {
                var character = context.Characters.FirstOrDefault(c => c.Id == characterId);
                if (character != null)
                {
                    exp = character.Level.ExpToNextLevel;
                }
            }

            return exp;
        }

        public static int GetPointsToReceive(int characterId)
        {
            int points = 0;
            using (var context = new ConsoleWorldContext())
            {
                var character = context.Characters.FirstOrDefault(c => c.Id == characterId);
                if (character != null)
                {
                    points = character.Level.PointsToReceive;
                }
            }

            return points;
        }

        public static List<Item> GetItemsForMagicWell(int money)
        {
            List<Item> items = new List<Item>();
            using (var context = new ConsoleWorldContext())
            {
                var candidateItems = context.Items
                    .Where(i => i.Price < money)
                    .ToList();
                int count = 0;
                while (money > 0 && candidateItems.Count > 0 && count < MaxAmountOfItemsFromMagicWell)
                {
                    var item = candidateItems[random.Next(candidateItems.Count)];
                    money -= item.Price;
                    items.Add(item);
                    candidateItems = context.Items
                    .Where(i => i.Price < money)
                    .ToList();
                    count++;
                }
            }

            return items;
        }

        public static Weapon GetWeaponForMagicWell(Character character, int money)
        {
            Weapon weapon = null;
            using (var context = new ConsoleWorldContext())
            {
                var weapons = context.Weapons
                    .Where(w => w.Price < money && w.RequiredLevel <= character.LevelId)
                    .ToList();
                if (weapons.Count > 0)
                {
                    weapon = weapons[random.Next(weapons.Count)];
                }
            }

            return weapon;
        }

        public static void SaveCharacter(Character character)
        {
            using (var context = new ConsoleWorldContext())
            {
                var characterInDb = context.Characters.FirstOrDefault(c => c.Id == character.Id);
                if (characterInDb != null)
                {
                    characterInDb.Class = character.Class;
                    characterInDb.MaxHp = character.MaxHp;
                    characterInDb.Hp = character.Hp;
                    characterInDb.MaxMp = character.MaxMp;
                    characterInDb.Mp = character.Mp;
                    characterInDb.Attack = character.Attack;
                    characterInDb.MagicAttack = character.MagicAttack;
                    characterInDb.Defense = character.Defense;
                    characterInDb.MagicDefense = character.MagicDefense;
                    characterInDb.Evade = character.Evade;
                    characterInDb.Accuracy = character.Accuracy;
                    characterInDb.EquippedWeaponId = character.EquippedWeaponId;
                    characterInDb.Exp = character.Exp;
                    characterInDb.Points = character.Points;
                    characterInDb.LevelId = character.LevelId;
                    characterInDb.Money = character.Money;
                    characterInDb.DungeonLevel = character.DungeonLevel;

                    context.SaveChanges();
                }
            }
        }

        public static List<Enemy> GetEnemies()
        {
            var enemies = new List<Enemy>();
            using (var context = new ConsoleWorldContext())
            {
                enemies.AddRange(context.Enemies.ToList());
            }

            return enemies;
        }

        public static void DeleteCharacter(int characterId)
        {
            using (var context = new ConsoleWorldContext())
            {
                context.CharacterItems.RemoveRange(context.CharacterItems.Where(ci => ci.CharacterId == characterId));
                context.Characters.Remove(context.Characters.FirstOrDefault(c => c.Id == characterId));
                context.SaveChanges();
            }
        }

        public static int GetItemQuantity(int characterId, int itemId)
        {
            int quantity = 0;
            using (var context = new ConsoleWorldContext())
            {
                var characterItem = context.CharacterItems.FirstOrDefault(ci => ci.CharacterId == characterId && ci.ItemId == itemId);
                if (characterItem != null)
                {
                    quantity += characterItem.Quantity;
                }
            }

            return quantity;
        }

        public static void EquipWeaponToCharacter(Character character, Weapon weapon)
        {
            using (var context = new ConsoleWorldContext())
            {
                var characterDb = context.Characters.FirstOrDefault(c => c.Id == character.Id);
                var weaponDb = context.Weapons.FirstOrDefault(w => w.Id == weapon.Id);
                if (characterDb != null && weaponDb != null)
                {
                    characterDb.EquippedWeaponId = weaponDb.Id;
                    characterDb.EquippedWeapon = weaponDb;
                    context.SaveChanges();

                    character.EquippedWeaponId = weapon.Id;
                    character.EquippedWeapon = weapon;
                }
            }
        }

        public static Item GetItem(string name)
        {
            
            using (var context = new ConsoleWorldContext())
            {
                var item = context.Items.FirstOrDefault(i => i.Name == name);
                return item;
            }
            
        }
    }
}