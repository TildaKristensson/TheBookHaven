using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Language { get; set; }

    public decimal PriceInKr { get; set; }

    public int? GenreId { get; set; }

    public DateOnly PublicationDate { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
