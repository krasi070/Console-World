namespace ConsoleWorld.Data
{
    using System.Linq;
    public static class Utility
    {
        public static void InitDb()
        {
            var context = new ConsoleWorldContext();
            context.Database.Initialize(true);
        }
        public static bool CheckCharacterNameInDB(string name)
        {
            using (var context=new ConsoleWorldContext())
            {
                if (context.Characters.Any(c => c.Name == name))
                {
                    return true;
                }
                return false;
            }            
        }
    }
}