using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.Interfaces;
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
        _dbContext.Departaments.Update(departament);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteDepartamentAsync(int id)
    {
        var departament = await _dbContext.Departaments.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NullReferenceException("Departamento no encontrado");
        
        departament.Active = false;
        
        await _dbContext.SaveChangesAsync();
    }

    // Queries
    public async Task<IEnumerable<Departament>> GetAllDepartamentsAsync()
    {
        return await _dbContext.Departaments.ToListAsync();
    }

    public async Task<Departament?> GetDepartamentByIdAsync(int id)
    {
        return await _dbContext.Departaments.FirstOrDefaultAsync(d => d.Id == id);
    }
}
