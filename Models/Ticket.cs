using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Ticket
{
    public string TicketId { get; set; } = null!;

    public DateTime PurchaseAt { get; set; }

    public int Price { get; set; }

    public string InvoiceId { get; set; } = null!;

    public string ScheduleId { get; set; } = null!;

    public int SeatId { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
