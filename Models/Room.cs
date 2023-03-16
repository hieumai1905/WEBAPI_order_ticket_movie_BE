using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Room
{
    public string RoomId { get; set; } = null!;

    public int NumberSeats { get; set; }

    public string Name { get; set; } = null!;

    public int AvailableSeats { get; set; }

    public string IdCinema { get; set; } = null!;

    public virtual Cinema IdCinemaNavigation { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();
}
