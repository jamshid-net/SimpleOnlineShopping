using Application.UseCases.Categories.Response;
using AutoMapper;
using Domain.Entities;


namespace Application.Common.Mappings;
public class CategoryMapping:Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryResponse>().ReverseMap();
    }
}
