using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WEBAPI_order_ticket.Models;

public partial class Room
{
    public string RoomId { get; set; } = ""!;

    public int NumberSeats { get; set; }

    public string Name { get; set; } = null!;

    public int AvailableSeats { get; set; }

    public string IdCinema { get; set; } = null!;
}
