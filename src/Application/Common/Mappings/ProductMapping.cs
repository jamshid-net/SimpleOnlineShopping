using Application.Common.HelperExtentions;
using Application.UseCases.Products.Commands;
using Application.UseCases.Products.Reponse;
using AutoMapper;
using Domain.Entities;
using Pagination.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings;
public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductCommand,Product>().ReverseMap();
       
        CreateMap<ProductResponse,Product>().ReverseMap();
        CreateMap<Pagination<ProductResponse>, Pagination<Product>>().ReverseMap();
    }
}
