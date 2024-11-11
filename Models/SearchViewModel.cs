using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class SearchViewModel
    {
        public List<Movie>? Movies { get; set; }
        public List<Book>? Books { get; set; }
        public List<Game>? Games { get; set; }
        public List<Music>? Music { get; set; }
        public string? SearchQuery { get; set; }
    }
}
