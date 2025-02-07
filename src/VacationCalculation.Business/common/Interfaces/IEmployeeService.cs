using VacationCalculation.Business.common.utils;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Interfaces;
public interface IEmployeeService
{
    // Query
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);

    // Command
    Task<Result<Employee>> CreateEmployeeAsync(Employee employee);
    Task<Result<bool>> UpdateEmployeeAsync(Employee employee);
    Task<Result<bool>> DeleteEmployeeAsync(int id);
}
