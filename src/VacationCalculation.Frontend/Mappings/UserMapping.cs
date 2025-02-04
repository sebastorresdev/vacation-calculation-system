using VacationCalculation.Data.Models;
using VacationCalculation.Frontend.Models.User;

namespace VacationCalculation.Frontend.Mappings;

public static class UserMapping
{
    public static UserViewModel ToViewModel(this User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            Email = user.Employee?.Email ?? string.Empty,
            Role = user.Role.Name
        };
    }
}
