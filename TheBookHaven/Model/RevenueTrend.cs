using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class RevenueTrend
{
    public int? Year { get; set; }

    public string? Month { get; set; }

    public int? TotalBooksSold { get; set; }

    public string TotalSalesAmount { get; set; } = null!;

    public string? MostPopularGenre { get; set; }
}
