using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Interfaces;
public interface IDepartamentService
{
    // Queries
    Task<IEnumerable<Departament>> GetAllDepartamentsAsync();
    Task<Departament?> GetDepartamentByIdAsync(int id);

    // Commands
    Task CreateDepartamentAsync(Departament departament);
    Task UpdateDepartamentAsync(Departament departament);
    Task DeleteDepartamentAsync(int id);
}
