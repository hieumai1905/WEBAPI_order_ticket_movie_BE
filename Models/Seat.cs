using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Seat
{
    public int SeatId { get; set; }

    public string RowNumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string TypeSeat { get; set; } = null!;

    public string RoomId { get; set; } = null!;

}
