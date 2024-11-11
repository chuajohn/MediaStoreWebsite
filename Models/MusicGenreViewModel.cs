using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models;

public class MusicGenreViewModel
{
    public List<Music>? Music { get; set; }
    public SelectList? Genres { get; set; }
    public string? MusicGenre { get; set; }
    public string? SearchString { get; set; }
}