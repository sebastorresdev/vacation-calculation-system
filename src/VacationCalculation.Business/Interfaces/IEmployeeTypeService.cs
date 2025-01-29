using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Interfaces;
public interface IEmployeeTypeService
{
    // Queries
    Task<IEnumerable<EmployeeType>> GetAllEmployeeTypesAsync();
    Task<EmployeeType?> GetEmployeeTypeByIdAsync(int id);

    // Commands
    Task CreateEmployeeTypeAsync(EmployeeType employeeType);
    Task UpdateEmployeeTypeAsync(EmployeeType employeeType);
    Task DeleteEmployeeTypeAsync(int id);
}
