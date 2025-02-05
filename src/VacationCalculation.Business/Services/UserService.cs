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
        if(!await IsUsernameUniqueAsync(user.Name))
            throw new InvalidOperationException($"Ya existe un nombre de usuario para {user.Name}");

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id && u.Active == true)
            ?? throw new NullReferenceException($"No existe el usuario con id {user.Id}");

        if((user.Name != existingUser.Name) && !await IsUsernameUniqueAsync(user.Name))
            throw new InvalidOperationException($"Ya existe un nombre de usuario para {user.Name}");
        

        existingUser.Name = user.Name;
        existingUser.RoleId = user.RoleId;
        existingUser.EmployeeId = user.EmployeeId;

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
        if(string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("El nombre de usuario no puede estar vacío", nameof(username));

        return !await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Name == username);
    }

}
