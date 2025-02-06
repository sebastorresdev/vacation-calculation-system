using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class RolePermission
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public virtual Role Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
