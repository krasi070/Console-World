namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}