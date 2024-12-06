using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class Genre
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
