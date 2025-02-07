using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.common.Validations;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class DepartamentService(VacationDbContext dbContext, DepartamentValidation departamentValidation) : IDepartamentService
{
    private readonly VacationDbContext _dbContext = dbContext;
    private readonly DepartamentValidation _departamentValidation = departamentValidation;

    // Commands
    public async Task<Result<Departament>> CreateDepartamentAsync(Departament departament)
    {
        var validationResult = await _departamentValidation.ValidateAsync(departament);

        if (!validationResult.IsValid)
            return validationResult.Errors;

        await _dbContext.Departaments.AddAsync(departament);
        await _dbContext.SaveChangesAsync();

        return departament;
    }
    public async Task<Result<bool>> UpdateDepartamentAsync(Departament departament)
    {
        var existingDepartament = await _dbContext.Departaments
            .FirstOrDefaultAsync(x => x.Id == departament.Id && x.Active == true);

        if (existingDepartament is null)
            return Error.NotFound("Departament.Error", "No se encontro el departamento");

        var validationResult = await _departamentValidation.ValidateAsync(departament);

        if (!validationResult.IsValid)
            return validationResult.Errors;

        existingDepartament.Name = departament.Name;
        _dbContext.Departaments.Update(existingDepartament);
        await _dbContext.SaveChangesAsync();

        return true;
    }
    public async Task<Result<bool>> DeleteDepartamentAsync(int id)
    {
        var departament = await _dbContext.Departaments
            .FirstOrDefaultAsync(x => x.Id == id && x.Active == true);

        if (departament is null)
            return Error.NotFound("Departament.Error", "No se encontro el departamento");

        departament.Active = false;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Queries
    public async Task<IEnumerable<Departament>> GetAllDepartamentsAsync()
    {
        return await _dbContext.Departaments
            .Where(d => d.Active == true)
            .ToListAsync();
    }

    public async Task<Departament?> GetDepartamentByIdAsync(int id)
    {
        return await _dbContext.Departaments
            .FirstOrDefaultAsync(d => d.Id == id && d.Active == true);
    }
}
