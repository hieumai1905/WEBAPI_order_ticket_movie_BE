using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class User
{
    public string UserId { get; set; } = ""!;

    public string Fullname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;
    public DateTime BirthDay { get; set; }
}
