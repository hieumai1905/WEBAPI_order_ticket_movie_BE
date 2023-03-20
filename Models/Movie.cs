using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WEBAPI_order_ticket.Models;

public partial class Movie
{
    public string MovieId { get; set; } = ""!;

    public string Title { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime ReleasedDate { get; set; } = DateTime.Now;

    public string Director { get; set; } = null!;

    public int Duration { get; set; }

    public string Poster { get; set; } = null!;

    public int AgeRating { get; set; }

    public int GenreId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Cast> Casts { get; } = new List<Cast>();
    [JsonIgnore]
    public virtual ICollection<Cinema> IdCinemas { get; } = new List<Cinema>();
}
