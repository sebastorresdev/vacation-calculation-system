namespace VacationCalculation.Data.Models;

public partial class EmployeeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DaysPerYear { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
