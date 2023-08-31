using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings;
public class UserMapping:Profile
{
    public UserMapping()
    {
        CreateMap<User, RegisterUserCommand>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();
    }
}
