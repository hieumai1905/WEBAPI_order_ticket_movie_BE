using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public int TotalPrice { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual User User { get; set; } = null!;
}
