using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public string? ArtistDescription { get; set; }

    public virtual ICollection<Vinyl> Vinyls { get; set; } = new List<Vinyl>();
}
