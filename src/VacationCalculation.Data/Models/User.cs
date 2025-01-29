using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual Role Role { get; set; } = null!;
}
