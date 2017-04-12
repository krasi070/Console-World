namespace ConsoleWorld.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Range(-100, 100)]
        public int PercentageIncrease { get; set; }

        public ItemType Type { get; set; }
    }
}