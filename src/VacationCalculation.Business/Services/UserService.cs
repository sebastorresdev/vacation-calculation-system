using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.common.Validations;
using VacationCalculation.Business.Errors;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Enums;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class UserService(VacationDbContext dbContext, UserValidation validation) : IUserService
{
    private readonly VacationDbContext _dbContext = dbContext;
    private readonly UserValidation _validation = validation;

    // Commands
    public async Task<Result<User>> CreateUserAsync(User user)
    {
        var result = await _validation.ValidateAsync(user);

        if (!result.IsValid)
            return result.Errors;

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    public async Task<Result<bool>> UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id && u.Active == true);

        if (existingUser is null)
            return UserErrors.UserNotFound();

        var result = await _validation.ValidateAsync(user);

        if (!result.IsValid)
            return result.Errors;

        existingUser.Name = user.Name;
        existingUser.RoleId = user.RoleId;
        existingUser.EmployeeId = user.EmployeeId;

        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<Result<bool>> DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.Active == true);

        if (user is null)
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
            .Include(u => u.Employee!.Departament)
            .Where(u => u.Active == true)
            .ToListAsync();
    }

    public Task<List<Role>> GetRolesAsync()
    {
        return _dbContext.Roles
            .AsNoTracking()
            .ToListAsync();
    }
}
