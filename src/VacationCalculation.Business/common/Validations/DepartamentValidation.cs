using Microsoft.EntityFrameworkCore;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Validations;
public class DepartamentValidation : AbstractValidator<Departament>
{
    public DepartamentValidation(VacationDbContext dbContext)
    {
        RuleForAsync(async d =>
        {
            return !await dbContext.Departaments.AnyAsync(x => x.Name == d.Name && x.Id != d.Id && x.Active == true);
        }, $"Ya existe un departamento con el mismo nombre");
    }
}
