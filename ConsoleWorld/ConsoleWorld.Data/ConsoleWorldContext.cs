namespace ConsoleWorld.Data
{
    using System.Data.Entity;
    using Models;
    using Models.Enemies;

    public class ConsoleWorldContext : DbContext
    {
        public ConsoleWorldContext()
            : base("name=ConsoleWorldContext")
        {
            //Database.SetInitializer(new ConsoleWorldInitializer());
        }

        public virtual DbSet<Character> Characters { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Weapon> Weapons { get; set; }

        public virtual DbSet<Level> Levels { get; set; }

        public virtual DbSet<Enemy> Enemies { get; set; }

        public virtual DbSet<CharacterItem> CharacterItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOptional(c => c.EquippedWeapon)
                .WithMany(w => w.CharactersEquippedWeapon);

            modelBuilder.Entity<CharacterItem>()
                .HasKey(ci => new
                {
                    ci.CharacterId,
                    ci.ItemId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}