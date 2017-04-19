namespace ConsoleWorld.Data
{
    using Models;
    using System.Linq;
    using System.Collections.Generic;

    public static class Utility
    {
        public static void InitDb()
        {
            var context = new ConsoleWorldContext();
            context.Database.Initialize(true);
        }
        public static bool CheckIfCharacterExists(string name)
        {
            using (var context = new ConsoleWorldContext())
            {
                if (context.Characters.Any(c => c.Name == name))
                {
                    return true;
                }
            }

            return false;
        }

        public static Character GetCharacterByName(string name)
        {
            using (var context = new ConsoleWorldContext())
            {
                return context.Characters.FirstOrDefault(c => c.Name == name);
            }
        }
        public static List<CharacterItem> GetItems()
        {
            using (var context = new ConsoleWorldContext())
            {
                return context.CharacterItems.ToList();
            }
        }
    }
}