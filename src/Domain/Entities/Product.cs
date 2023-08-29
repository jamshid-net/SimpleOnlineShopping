using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public float ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
