using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class EmployeTypeService(VacationDbContext dbContext) : IEmployeeTypeService
{
    private readonly VacationDbContext _dbContext = dbContext;
    // Commands
    public async Task CreateEmployeeTypeAsync(EmployeeType employeeType)
    {
        await _dbContext.EmployeeTypes.AddAsync(employeeType);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateEmployeeTypeAsync(EmployeeType employeeType)
    {
        var existingEmployeeType = await _dbContext.EmployeeTypes
            .FirstOrDefaultAsync(t => t.Id == employeeType.Id && t.Active == true)
            ?? throw new NullReferenceException("Tipo de empleado no encontrado");
        
        existingEmployeeType.Name = employeeType.Name;
        existingEmployeeType.DaysPerYear = employeeType.DaysPerYear;

        _dbContext.EmployeeTypes.Update(existingEmployeeType);
        
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteEmployeeTypeAsync(int id)
    {
        var employeeTypes = await _dbContext.EmployeeTypes
            .FirstOrDefaultAsync(x => x.Id == id && x.Active == true)
            ?? throw new NullReferenceException("No existe el tipo de empleado");

        employeeTypes.Active = false;

        await _dbContext.SaveChangesAsync();
    }

    // Queries
    public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypesAsync()
    {
        return await _dbContext.EmployeeTypes
            .Where(t => t.Active == true)
            .ToListAsync();
    }

    public async Task<EmployeeType?> GetEmployeeTypeByIdAsync(int id)
    {
        return await _dbContext.EmployeeTypes
            .FirstOrDefaultAsync(t => t.Id == id && t.Active == true);
    }
}
