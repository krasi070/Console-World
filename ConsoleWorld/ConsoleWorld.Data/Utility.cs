namespace ConsoleWorld.Data
{
    public static class Utility
    {
        public static void InitDb()
        {
            var context = new ConsoleWorldContext();
            context.Database.Initialize(true);
        }
    }
}