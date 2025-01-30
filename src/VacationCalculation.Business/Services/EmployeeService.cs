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
        var existingEmployee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == employee.Id && e.Active == true)
            ?? throw new NullReferenceException("Employee not found");

        existingEmployee.Name = employee.Name;
        existingEmployee.PaternalSurname = employee.PaternalSurname;
        existingEmployee.MaternalSurname = employee.MaternalSurname;
        existingEmployee.DateEntry = employee.DateEntry;
        existingEmployee.Birthday = employee.Birthday;
        existingEmployee.Email = employee.Email;
        existingEmployee.DepartamentId = employee.DepartamentId;
        existingEmployee.EmployeeTypeId = employee.EmployeeTypeId;


        _dbContext.Employees.Update(existingEmployee);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == id && e.Active == true)
            ?? throw new NullReferenceException("Employee not found");
        
        employee.Active = false;
        await _dbContext.SaveChangesAsync();
    }
    
}
