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

        existingUser.Password = user.Password;
        existingUser.RoleId = user.RoleId;

        _dbContext.Users.Update(existingUser);
        await _dbContext.SaveChangesAsync();
    }
    public Task DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Queries
    public Task<User?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    
}
