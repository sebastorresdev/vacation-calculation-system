using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.Interfaces;
public interface IUserService
{
    // Queries
    Task<User?> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<IEnumerable<Role>> GetRolesAsync();

    // Commands
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);

}
