using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderStatusId { get; set; }

    public int PaymentId { get; set; }

    public int ClientId { get; set; }

    public int OrderItemId { get; set; }

    public decimal OrderPrice { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;
}
