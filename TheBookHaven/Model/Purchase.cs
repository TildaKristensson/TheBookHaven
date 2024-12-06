using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class Purchase
{
    public int Id { get; set; }

    public Guid? PurchaseId { get; set; }

    public string Isbn { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual PurchaseDetail? PurchaseNavigation { get; set; }
}
