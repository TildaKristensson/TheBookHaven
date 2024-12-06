using System;
using System.Collections.Generic;

namespace TheBookHaven.Model;

public partial class Author
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Book> Isbns { get; set; } = new List<Book>();
}
