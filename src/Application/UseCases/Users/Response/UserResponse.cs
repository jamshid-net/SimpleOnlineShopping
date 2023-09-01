using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Response;
public class UserResponse
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string? ShortAddress { get; set; }

    public string? UserPicture { get; set; }

    public List<Role>? Roles { get; set; }
    
}
