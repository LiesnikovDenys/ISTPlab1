using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public string? BrandDescription { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
