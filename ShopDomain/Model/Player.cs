using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Player
{
    public int PlayerId { get; set; }

    public int BrandId { get; set; }

    public short Bluetooth { get; set; }

    public short Speaker { get; set; }

    public string Price { get; set; } = null!;

    public int Stock { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
