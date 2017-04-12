namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Weapon
    {
        public Weapon()
        {
            this.CharactersOwningWeapon = new HashSet<Character>();
            this.CharactersEquippedWeapon = new HashSet<Character>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Damage { get; set; }

        [Range(0, int.MaxValue)]
        public int MagicPower { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Range(0, int.MaxValue)]
        public int RequiredLevel { get; set; }

        public virtual ICollection<Character> CharactersOwningWeapon { get; set; }

        public virtual ICollection<Character> CharactersEquippedWeapon { get; set; }
    }
}