using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class TitlesPerAuthor
{
    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? Titles { get; set; }

    public string StockValue { get; set; } = null!;
}
