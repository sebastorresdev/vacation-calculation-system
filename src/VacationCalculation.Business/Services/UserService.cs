using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Data.Data;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Services;
public class UserService(VacationDbContext dbContext) : IUserService
{
    private readonly VacationDbContext _dbContext = dbContext;

    // Commands
    public async Task CreateUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id && u.Active == true)
            ?? throw new NullReferenceException($"No existe el usuario con id {user.Id}");

        existingUser.Name = user.Name;
        existingUser.RoleId = user.RoleId;
        existingUser.EmployeeId = user.EmployeeId;

        _dbContext.Users.Update(existingUser);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.Active == true)
            ?? throw new NullReferenceException($"No existe el usuario con id {id}");

        user.Active = false;
        await _dbContext.SaveChangesAsync();
    }

    // Queries
    public Task<User?> GetUserByIdAsync(int id)
    {
        return _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id && u.Active == true);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _dbContext.Users
            .Include(u => u.Role)
            .Include(u => u.Employee)
            .Where(u => u.Active == true).ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await _dbContext.Roles.ToListAsync();
    }
}
