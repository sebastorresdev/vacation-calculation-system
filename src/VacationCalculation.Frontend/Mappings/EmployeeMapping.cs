using VacationCalculation.Data.Models;
using VacationCalculation.Frontend.Models.Employee;

namespace VacationCalculation.Frontend.Mappings;

public static class EmployeeMapping
{
    public static Employee ToEmployee(this CreateEmployeeViewModel employeeViewModel)
    {
        return new Employee
        {
            Name = employeeViewModel.Name,
            PaternalSurname = employeeViewModel.PaternalSurname,
            MaternalSurname = employeeViewModel.MaternalSurname,
            Email = employeeViewModel.Email,
            DateEntry = DateOnly.FromDateTime(employeeViewModel.DateEntry),
            Birthday = DateOnly.FromDateTime(employeeViewModel.Birthday),
            EmployeeTypeId = employeeViewModel.EmployeeTypeId,
            DepartamentId = employeeViewModel.DepartamentId
        };
    }

    public static Employee ToEmployee(this UpdateEmployeeViewModel employeeViewModel)
    {
        return new Employee
        {
            Id = employeeViewModel.Id,
            Name = employeeViewModel.Name,
            PaternalSurname = employeeViewModel.PaternalSurname,
            MaternalSurname = employeeViewModel.MaternalSurname,
            Email = employeeViewModel.Email,
            DateEntry = DateOnly.FromDateTime(employeeViewModel.DateEntry),
            Birthday = DateOnly.FromDateTime(employeeViewModel.Birthday),
            EmployeeTypeId = employeeViewModel.EmployeeTypeId,
            DepartamentId = employeeViewModel.DepartamentId
        };
    }

    public static EmployeeViewModel ToViewModel(this Employee employee)
    {
        return new EmployeeViewModel
        {
            Id = employee.Id,
            FullName = $"{employee.Name} {employee.PaternalSurname} {employee.MaternalSurname}",
            Email = employee.Email,
            DateEntry = employee.DateEntry.ToString("dd/MM/yyyy"),
            Birthday = employee.Birthday.ToString("dd/MM/yyyy"),
            EmployeeType = employee.EmployeeType.Name,
            Departament = employee.Departament.Name
        };
    }

    public static UpdateEmployeeViewModel ToUpdateViewModel(this Employee employee)
    {
        return new UpdateEmployeeViewModel
        {
            Id = employee.Id,
            Name = employee.Name,
            PaternalSurname = employee.PaternalSurname,
            MaternalSurname = employee.MaternalSurname,
            Email = employee.Email,
            DateEntry = employee.DateEntry.ToDateTime(TimeOnly.MinValue),
            Birthday = employee.Birthday.ToDateTime(TimeOnly.MinValue),
            EmployeeTypeId = employee.EmployeeTypeId,
            DepartamentId = employee.DepartamentId
        };
    }
}
