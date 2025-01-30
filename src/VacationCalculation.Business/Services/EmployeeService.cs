using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class EmployeeService(VacationDbContext dbContext) : IEmployeeService
{
    private readonly VacationDbContext _dbContext = dbContext;

    // Queries
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _dbContext.Employees
            .Where(Employee => Employee.Active == true)
            .Include(Employee => Employee.Departament)
            .Include(Employee => Employee.EmployeeType)
            .ToListAsync();
    }
    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id && e.Active == true);
    }

    // Commands
    public async Task CreateEmployeeAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var editEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id)
            ?? throw new NullReferenceException("Employee not found");

        editEmployee.Name = employee.Name;
        editEmployee.PaternalSurname = employee.PaternalSurname;
        editEmployee.MaternalSurname = employee.MaternalSurname;
        editEmployee.DateEntry = employee.DateEntry;
        editEmployee.Birthday = employee.Birthday;
        editEmployee.Email = employee.Email;
        editEmployee.DepartamentId = employee.DepartamentId;
        editEmployee.EmployeeTypeId = employee.EmployeeTypeId;


        _dbContext.Employees.Update(editEmployee);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new NullReferenceException("Employee not found");
        employee.Active = false;
        await _dbContext.SaveChangesAsync();
    }
    
}
