using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Vinyl
{
    public int VinilId { get; set; }

    public string VinilName { get; set; } = null!;

    public int ArtistId { get; set; }

    public int GenreId { get; set; }

    public string Price { get; set; } = null!;

    public int Stock { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
