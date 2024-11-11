using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<MvcMovie.Models.Book> Book { get; set; }
        public DbSet<MvcMovie.Models.Game> Game { get; set; }
        public DbSet<MvcMovie.Models.Music> Music { get; set; }
        public DbSet<MvcMovie.Models.CartItem> ShoppingCartItems { get; set; }
    }
}
