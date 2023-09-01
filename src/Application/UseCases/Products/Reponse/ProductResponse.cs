using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Reponse;
public class ProductResponse
{
    public int Id { get; set; }

    public string ProductName { get; set; } 

    public float ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public  Category? Category { get; set; }
}
