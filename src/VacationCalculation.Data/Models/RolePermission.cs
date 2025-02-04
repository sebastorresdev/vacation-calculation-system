using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class RolePermission
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PermissionId { get; set; }

    public virtual Role? Permission { get; set; }

    public virtual Role? User { get; set; }
}
