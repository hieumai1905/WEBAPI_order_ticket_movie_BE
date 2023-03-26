using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Schedule
{
    public string ScheduleId { get; set; } = ""!;

    public DateTime ShowTime { get; set; }

    public DateTime EndTime { get; set; }

    public int Price { get; set; }

    public string MovieId { get; set; } = null!;
    public string RoomId { get; set; } = null!;
}
