using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
