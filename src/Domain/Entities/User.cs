using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ShortAddress { get; set; }

    public string? UserPicture { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
