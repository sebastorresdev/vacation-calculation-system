using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class DepartamentService(VacationDbContext dbContext) : IDepartamentService
{
    private readonly VacationDbContext _dbContext = dbContext;

    // Commands
    public async Task CreateDepartamentAsync(Departament departament)
    {
        await _dbContext.Departaments.AddAsync(departament);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateDepartamentAsync(Departament departament)
    {
        var existingDepartament = await _dbContext.Departaments
            .FirstOrDefaultAsync(x => x.Id == departament.Id && x.Active == true)
            ?? throw new NullReferenceException("Departamento no encontrado");

        existingDepartament.Name = departament.Name;

        _dbContext.Departaments.Update(existingDepartament);

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteDepartamentAsync(int id)
    {
        var departament = await _dbContext.Departaments
            .FirstOrDefaultAsync(x => x.Id == id && x.Active == true)
            ?? throw new NullReferenceException("Departamento no encontrado");
        
        departament.Active = false;
        
        await _dbContext.SaveChangesAsync();
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
