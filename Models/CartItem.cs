using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // It's better to use a single identifier to track the item
        public int? MovieId { get; set; }
        public int? MusicId { get; set; }
        public int? BookId { get; set; }
        public int? GameId { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // These virtual properties are used for navigation
        public virtual Movie? Movie { get; set; }
        public virtual Music? Music { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Game? Game { get; set; }
    }
}
