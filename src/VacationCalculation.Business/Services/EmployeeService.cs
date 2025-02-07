using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.common.Validations;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class EmployeeService(VacationDbContext dbContext, EmployeeValidation employeeValidation) : IEmployeeService
{
    private readonly VacationDbContext _dbContext = dbContext;
    private readonly EmployeeValidation _employeeValidation = employeeValidation;

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
    public async Task<Result<Employee>> CreateEmployeeAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();

        return employee;
    }
    public async Task<Result<bool>> UpdateEmployeeAsync(Employee employee)
    {
        var validationResult = await _employeeValidation.ValidateAsync(employee);

        if (!validationResult.IsValid)
            return validationResult.Errors;

        var existingEmployee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == employee.Id && e.Active == true);

        if (existingEmployee == null)
            return Error.NotFound("Employee.Error","Employee not found");


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

        return true;
    }
    public async Task<Result<bool>> DeleteEmployeeAsync(int id)
    {
        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == id && e.Active == true);

        if(employee is null)
            return Error.NotFound("Employee.Error", "Employee not found");

        employee.Active = false;
        await _dbContext.SaveChangesAsync();

        return true;
    }
    
}
