using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Ticket
{
    public string TicketId { get; set; } = ""!;

    public DateTime PurchaseAt { get; set; } = DateTime.Now;

    public int Price { get; set; }

    public string InvoiceId { get; set; } = null!;

    public string ScheduleId { get; set; } = null!;

    public int SeatId { get; set; }
}
