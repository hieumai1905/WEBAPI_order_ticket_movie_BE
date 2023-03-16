using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Schedule
{
    public string ScheduleId { get; set; } = null!;

    public DateTime ShowTime { get; set; }

    public DateTime EndTime { get; set; }

    public int Price { get; set; }

    public string MovieId { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
