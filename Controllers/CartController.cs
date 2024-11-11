using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class CartController : Controller
    {
        private readonly MvcMovieContext _context;

        public CartController(MvcMovieContext context)
        {
            _context = context;
        }

        // Method to add a movie to the cart
        [HttpPost]
        public async Task<IActionResult> AddMovieToCart(int movieId, int quantity = 1)
        {
            var movie = await _context.Movie.FindAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.MovieId == movieId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    MovieId = movieId,
                    Quantity = quantity,
                    Price = movie.Price,
                    Movie = movie
                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }

        // Method to add a game to the cart
        [HttpPost]
        public async Task<IActionResult> AddGameToCart(int gameId, int quantity = 1)
        {
            var game = await _context.Game.FindAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.GameId == gameId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    GameId = gameId,
                    Quantity = quantity,
                    Price = game.Price,
                    Game = game
                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }

        // Method to add music to the cart
        [HttpPost]
        public async Task<IActionResult> AddMusicToCart(int musicId, int quantity = 1)
        {
            var music = await _context.Music.FindAsync(musicId);
            if (music == null)
            {
                return NotFound();
            }

            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.MusicId == musicId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    MusicId = musicId,
                    Quantity = quantity,
                    Price = music.Price,
                    Music = music
                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }

        // Method to add a book to the cart
        [HttpPost]
        public async Task<IActionResult> AddBookToCart(int bookId, int quantity = 1)
        {
            var book = await _context.Book.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.BookId == bookId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    BookId = bookId,
                    Quantity = quantity,
                    Price = book.Price,
                    Book = book
                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }


        // View Cart
        public async Task<IActionResult> Cart()
        {
            // Fetch cart items from the database
            var cartItems = await _context.ShoppingCartItems
                .Include(ci => ci.Book)  // Include Book if necessary
                .Include(ci => ci.Movie)
                .Include(ci => ci.Music)
                .Include(ci => ci.Game)
                .ToListAsync();

            // Create CartViewModel and populate it with the cart items
            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems
            };

            // Return the CartViewModel to the view
            return View(cartViewModel);
        }

        // Remove item from cart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(id);
            if (cartItem == null) return NotFound();

            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            if (quantity < 1)
            {
                return BadRequest("Quantity must be at least 1.");
            }

            var cartItem = await _context.ShoppingCartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity = quantity; // Update quantity
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction("Cart"); // Redirect back to cart view
        }
        // GET: Checkout
        public IActionResult Checkout()
        {
            // You may want to create a view model for the checkout
            var checkoutViewModel = new CheckoutViewModel
            {
                // Initialize any required properties
            };
            return View(checkoutViewModel);
        }
        [HttpPost]
        public IActionResult SubmitCheckout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the checkout (e.g., save order to the database)
                // Redirect to a confirmation page or show a success message

                return RedirectToAction("CheckoutConfirmation");
            }

            // If the model state is invalid, return to the checkout view with validation errors
            return View("Checkout", model);
        }
        public IActionResult CheckoutConfirmation()
        {
            return View();
        }
    }
}
