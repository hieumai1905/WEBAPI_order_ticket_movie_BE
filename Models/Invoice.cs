using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = ""!;

    public DateTime CreateAt { get; set; } = DateTime.Now;

    public int TotalPrice { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string UserId { get; set; } = null!;
}
