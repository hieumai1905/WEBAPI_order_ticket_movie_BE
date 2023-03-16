using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Cast
{
    public string CastId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime BirthDay { get; set; }

    public string Nationality { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
