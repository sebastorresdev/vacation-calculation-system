using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public bool? Active { get; set; }
}
