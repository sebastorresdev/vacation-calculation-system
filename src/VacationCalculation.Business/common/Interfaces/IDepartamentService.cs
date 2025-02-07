using VacationCalculation.Business.common.utils;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Interfaces;
public interface IDepartamentService
{
    // Queries
    Task<IEnumerable<Departament>> GetAllDepartamentsAsync();
    Task<Departament?> GetDepartamentByIdAsync(int id);

    // Commands
    Task<Result<Departament>> CreateDepartamentAsync(Departament departament);
    Task<Result<bool>> UpdateDepartamentAsync(Departament departament);
    Task<Result<bool>> DeleteDepartamentAsync(int id);
}
