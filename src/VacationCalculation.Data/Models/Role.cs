﻿using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
