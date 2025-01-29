using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Interfaces;
public interface IEmployeeService
{
    // Query
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);

    // Command
    Task CreateEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int id);
}
