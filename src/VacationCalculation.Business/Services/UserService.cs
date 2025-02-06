using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.Errors;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class UserService(VacationDbContext dbContext) : IUserService
{
    private readonly VacationDbContext _dbContext = dbContext;

    // Commands
    public async Task<Result<User>> CreateUserAsync(User user)
    {
        if(!await IsUsernameUniqueAsync(user.Name))
            return UserErrors.UserExisting(user.Name);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    public async Task<Result<bool>> UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id && u.Active == true);

        if (existingUser is null)
            return UserErrors.UserNotFound();

        if((user.Name != existingUser.Name) && !await IsUsernameUniqueAsync(user.Name))
            return UserErrors.UserExisting(user.Name);
        

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

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .Include(u => u.Employee)
            .Where(u => u.Active == true)
            .ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .ToListAsync();
    }

    private async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Name == username && u.Active == true);
    }
}
