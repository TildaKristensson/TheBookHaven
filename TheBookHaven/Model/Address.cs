using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class Address
{
    public int Id { get; set; }

    public string? Address1 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int BookStoreId { get; set; }

    public virtual BookStore BookStore { get; set; } = null!;
}
