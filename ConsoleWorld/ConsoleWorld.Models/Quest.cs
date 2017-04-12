namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Quest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int MoneyReward { get; set; }

        public int? ItemRewardId { get; set; }

        public virtual Item ItemReward { get; set; }

        public int? WeaponRewardId { get; set; }

        public virtual Weapon WeaponReward { get; set; }
    }
}