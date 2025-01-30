using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PaternalSurname { get; set; } = null!;

    public string? MaternalSurname { get; set; }

    public DateOnly DateEntry { get; set; }

    public DateOnly Birthday { get; set; }

    public string Email { get; set; } = null!;

    public int DepartamentId { get; set; }

    public int EmployeeTypeId { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual Departament Departament { get; set; } = null!;

    public virtual EmployeeType EmployeeType { get; set; } = null!;

    public virtual ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();
}
