using System;
using System.Collections.Generic;

namespace ShopDomain.Model;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public string? GenreDescription { get; set; }

    public virtual ICollection<Vinyl> Vinyls { get; set; } = new List<Vinyl>();
}
