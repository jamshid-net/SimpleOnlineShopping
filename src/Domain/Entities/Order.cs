using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual List<Product>? Products { get; set; }
}
