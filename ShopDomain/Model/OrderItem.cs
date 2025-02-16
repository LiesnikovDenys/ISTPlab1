using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? VinilId { get; set; }

    public int? PlayerId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Player? Player { get; set; }

    public virtual Vinyl? Vinil { get; set; }
}
