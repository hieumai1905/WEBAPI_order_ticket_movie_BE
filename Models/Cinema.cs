using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Cinema
{
    public string IdCinema { get; set; } = null!;

    public string NameCinema { get; set; } = null!;

    public string AddresCinama { get; set; } = null!;

    public string PhoneCinema { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
