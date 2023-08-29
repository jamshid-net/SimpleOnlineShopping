using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
