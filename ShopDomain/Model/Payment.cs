using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string PaymentType { get; set; } = null!;

    public short PaymentStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
