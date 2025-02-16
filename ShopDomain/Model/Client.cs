using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Client
{
    public int ClientId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string Admin { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
