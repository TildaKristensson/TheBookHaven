using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class StockBalance
{
    public int BookStoreId { get; set; }

    public string Isbn { get; set; } = null!;

    public int UnitsInStock { get; set; }

    public virtual BookStore BookStore { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;
}
