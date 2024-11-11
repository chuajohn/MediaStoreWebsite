using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcMovieContext _context; // Assuming this is your DB context

        public HomeController(ILogger<HomeController> logger, MvcMovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Other actions...

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(); // You can return an empty view or handle it differently
            }

            // Search Movies
            var movies = _context.Movie
                .Where(m => m.Title.Contains(query) || m.Genre.Contains(query));

            // Search Books
            var books = _context.Book
                .Where(b => b.Title.Contains(query) || b.Genre.Contains(query));

            // Search Games
            var games = _context.Game
                .Where(g => g.Title.Contains(query) || g.Genre.Contains(query));

            // Search Music
            var music = _context.Music
                .Where(m => m.Title.Contains(query) || m.Genre.Contains(query));

            // Combine all results into a single model
            var searchResults = new SearchViewModel
            {
                Movies = await movies.ToListAsync(),
                Books = await books.ToListAsync(),
                Games = await games.ToListAsync(),
                Music = await music.ToListAsync(),
                SearchQuery = query
            };

            return View(searchResults); // You will need to create a corresponding view for this
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
