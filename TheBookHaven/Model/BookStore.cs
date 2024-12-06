using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class BookStore
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
