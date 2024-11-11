using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your shipping address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select a payment method.")]
        public string PaymentMethod { get; set; }

        // You can add more properties if needed, e.g., Credit Card details
    }
}
