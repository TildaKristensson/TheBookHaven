using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class PurchaseDetail
{
    public Guid Id { get; set; }

    public DateOnly? DayOfPurchase { get; set; }

    public int BookStoreId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
