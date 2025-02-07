using Microsoft.EntityFrameworkCore;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Enums;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Validations;
public class EmployeeValidation : AbstractValidator<Employee>
{
    public EmployeeValidation(VacationDbContext dbContext)
    {
        RuleForAsync(async e =>
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.EmployeeId == e.Id && u.Active == true);

            if (user is null || user.RoleId != (int)RoleType.Boss)
                return true;

            return !await dbContext.Users
                .AnyAsync(u => u.RoleId == (int)RoleType.Boss &&
                               u.Employee != null &&
                               u.EmployeeId != e.Id &&
                               u.Employee.DepartamentId == e.DepartamentId &&
                               u.Active == true);
        }, "El empleado tiene un rol de JEFE y no puede asignarse el departamento que ya tiene un rol de JEFE ocupado.");
    }
}
