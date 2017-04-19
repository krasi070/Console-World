namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CharacterItem
    {
        public CharacterItem()
        {
        }

        public CharacterItem(int characterId, int itemId, int quantity)
        {
            this.CharacterId = characterId;
            this.ItemId = itemId;
            this.Quantity = quantity;
        }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}