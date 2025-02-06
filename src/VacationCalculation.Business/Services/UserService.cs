using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.Errors;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Enums;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class UserService(VacationDbContext dbContext) : IUserService
{
    private readonly VacationDbContext _dbContext = dbContext;

    // Commands
    public async Task<Result<User>> CreateUserAsync(User user)
    {
        // Verficar si no existe un nombre usuario igual
        if(!await IsUsernameUniqueAsync(user.Name))
            return UserErrors.UserExisting(user.Name);

        if(user.EmployeeId is not null && !await IsEmployeeAvailable(user.EmployeeId.Value))
            return UserErrors.UserEmployeeAlreadyAssigned();

        // Verfica si se le puede asignar el rol de jefe
        if(user.EmployeeId is not null &&
           user.RoleId == ((int)RoleType.Boos) &&
           !await RoleBossIsAvailable(user.EmployeeId.Value, user))
            return UserErrors.UserExistingRole();

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    public async Task<Result<bool>> UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id && u.Active == true);

        if(existingUser is null)
            return UserErrors.UserNotFound();

        if((user.Name != existingUser.Name) && !await IsUsernameUniqueAsync(user.Name))
            return UserErrors.UserExisting(user.Name);

        if( user.EmployeeId != existingUser.EmployeeId &&
            user.EmployeeId is not null &&
            !await IsEmployeeAvailable(user.EmployeeId.Value))
            return UserErrors.UserEmployeeAlreadyAssigned();

        if( user.EmployeeId is not null &&
            user.RoleId == ((int)RoleType.Boos) &&
            !await RoleBossIsAvailable(user.EmployeeId.Value, existingUser))
            return UserErrors.UserExistingRole();
        
        if (user.EmployeeId is not null)

        existingUser.Name = user.Name;
        existingUser.RoleId = user.RoleId;
        existingUser.EmployeeId = user.EmployeeId;

        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<Result<bool>> DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.Active == true);

        if(user is null)
            return UserErrors.UserNotFound();

        user.Active = false;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Queries
    public Task<User?> GetUserByIdAsync(int id)
    {
        return _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .Include(u => u.Employee)
            .FirstOrDefaultAsync(u => u.Id == id && u.Active == true);
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .Include(u => u.Employee)
            .Where(u => u.Active == true)
            .ToListAsync();
    }

    public Task<List<Role>> GetRolesAsync()
    {
        return _dbContext.Roles
            .AsNoTracking()
            .ToListAsync();
    }

    private async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Name == username && u.Active == true);
    }

    private async Task<bool> RoleBossIsAvailable(int employeeId, User user)
    {
        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId && e.Active == true);

        if(employee is null)
            return true;

        var existingBoss = _dbContext.Users
            .Include(u => u.Employee)
            .FirstOrDefault(u => u.Employee != null 
                && u.Employee.DepartamentId == employee.DepartamentId 
                && u.RoleId == ((int)RoleType.Boos)
                && u.Active == true);

        return existingBoss is null || existingBoss == user;
    }

    private async Task<bool> IsEmployeeAvailable(int employeeId)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.EmployeeId == employeeId && u.Active == true);
    }
}
