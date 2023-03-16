using System;
using System.Collections.Generic;

namespace WEBAPI_order_ticket.Models;

public partial class User
{
    public string UserId { get; set; } = ""!;

    public string Fullname { get; set; } = ""!;

    public string Phone { get; set; } = ""!;

    public string Email { get; set; } = ""!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = ""!;

    public string Address { get; set; } = ""!;
    public DateTime BirthDay { get; set; } = DateTime.Now;
}
