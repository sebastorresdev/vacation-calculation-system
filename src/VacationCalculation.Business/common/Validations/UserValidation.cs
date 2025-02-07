using Microsoft.EntityFrameworkCore;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Enums;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Validations;
public class UserValidation : AbstractValidator<User>
{
    private readonly VacationDbContext _dbContext;
    public UserValidation(VacationDbContext dbContext)
    {
        _dbContext = dbContext;
        RuleForAsync(IsUsernameUnique, "El nombre de usuario ya existe");
        RuleForAsync(IsEmployeeActiveAndAvailable, "El empleado ya tiene un usuario activo");
        RuleForAsync(RoleBossIsAvailable, "Ya existe un jefe de departamento");
    }
    
    private async Task<bool> IsUsernameUnique(User user)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Name == user.Name && u.Active == true && u.Id != user.Id);
    }
    private async Task<bool> IsEmployeeActiveAndAvailable(User user)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.EmployeeId == user.EmployeeId && u.Active == true && u.Id != user.Id);
    }
    private async Task<bool> RoleBossIsAvailable(User user)
    {
        if (user.RoleId != (int)RoleType.Boss)
            return true;

        var departamentId = (await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == user.EmployeeId && e.Active == true))?.DepartamentId;

        if (departamentId is null)
            return true;

        var existingBoss = _dbContext.Users
            .Include(u => u.Employee)
            .FirstOrDefault(
                u => u.Employee != null && 
                u.Employee.DepartamentId == departamentId &&
                u.RoleId == ((int)RoleType.Boss) && 
                u.Active == true &&
                u.Id != user.Id);

        return existingBoss is null;
    }
}
