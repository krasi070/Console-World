namespace ConsoleWorld.Data
{
    using System.Data.Entity;
    using Models;

    public class ConsoleWorldContext : DbContext
    {
        public ConsoleWorldContext()
            : base("name=ConsoleWorldContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ConsoleWorldContext>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Character> Characters { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Weapon> Weapons { get; set; }

        public virtual DbSet<Level> Levels { get; set; }

        public virtual DbSet<Quest> Quests { get; set; }

        public virtual DbSet<CharacterItem> CharacterItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOptional(c => c.EquippedWeapon)
                .WithMany(w => w.CharactersEquippedWeapon);

            modelBuilder.Entity<Weapon>()
                .HasMany(w => w.CharactersOwningWeapon)
                .WithMany(c => c.Weapons)
                .Map(cs =>
                {
                    cs.ToTable("CharacterWeapons");
                    cs.MapLeftKey("Weapon_Id");
                    cs.MapRightKey("Character_Id");
                });

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