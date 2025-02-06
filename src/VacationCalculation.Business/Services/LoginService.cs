using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Contracts;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.common.utils;
using VacationCalculation.Business.Errors;
using VacationCalculation.Data.Data;

namespace VacationCalculation.Business.Services;

public class LoginService(VacationDbContext dbContext) : ILoginService
{
    private readonly VacationDbContext _dbContext = dbContext;

    public async Task<Result<LoginResponse>> LoginAsync(string username, string password)
    {
        var user = await _dbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Name == username && u.Password == password);

        if (user == null)
            return UserErrors.UserNotFound();

        var permissions = await _dbContext
            .RolePermissions
            .Where(rp => rp.RoleId == user.RoleId)
            .Select(rp => rp.Permission.Name)
            .ToListAsync();

        return new LoginResponse(user.Id, user.Name, user.Role.Name, permissions);
    }
}