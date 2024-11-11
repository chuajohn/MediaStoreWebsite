using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcGameContext : DbContext
    {
        public MvcGameContext (DbContextOptions<MvcGameContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Game> Game { get; set; } = default!;
    }
}
