using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WEBAPI_order_ticket.Models;

public partial class Cinema
{
    public string IdCinema { get; set; } = ""!;

    public string NameCinema { get; set; } = null!;

    public string ImageCinema { get; set; } = null!;

    public string AddresCinama { get; set; } = null!;

    public string PhoneCinema { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
