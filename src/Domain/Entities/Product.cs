using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public float ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    [JsonIgnore]
    public virtual List<Order>? Orders { get; set; }
}
