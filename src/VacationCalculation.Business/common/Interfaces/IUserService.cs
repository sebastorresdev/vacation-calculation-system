using VacationCalculation.Business.common.utils;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Business.common.Interfaces;
public interface IUserService
{
    // Queries
    Task<User?> GetUserByIdAsync(int id);
    Task<List<User>> GetUsersAsync();
    Task<List<Role>> GetRolesAsync();

    // Commands
    Task<Result<User>> CreateUserAsync(User user);
    Task<Result<bool>> UpdateUserAsync(User user);
    Task<Result<bool>> DeleteUserAsync(int id);

}
