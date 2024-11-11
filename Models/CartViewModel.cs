using System.Collections.Generic;
using System.Linq; // Make sure to include this

namespace MvcMovie.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Ensure you reference the correct property for the total price
        public decimal TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);
    }
}
