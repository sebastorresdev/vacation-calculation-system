namespace VacationCalculation.Frontend.Models.Employee;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string DateEntry { get; set; }
    public required string Birthday { get; set; }
    public required string EmployeeType { get; set; }
    public required string Departament { get; set; }
}