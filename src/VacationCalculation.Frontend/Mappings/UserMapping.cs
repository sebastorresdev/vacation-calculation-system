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
            Name = user.Name,
            Email = user.Employee?.Email ?? string.Empty,
            Role = user.Role.Name
        };
    }

    public static User ToUser(this CreateUserViewModel viewModel)
    {
        return new User
        {
            Name = viewModel.Name,
            Password = viewModel.Password,
            RoleId = viewModel.RoleId,
            EmployeeId = viewModel.EmployeeId
        };
    }

    public static UpdateUserViewModel ToUpdateViewModel(this User user)
    {
        return new UpdateUserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            RoleId = user.RoleId,
            EmployeeId = user.EmployeeId
        };
    }

    public static User ToUser(this UpdateUserViewModel viewModel)
    {
        return new User
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            RoleId = viewModel.RoleId,
            EmployeeId = viewModel.EmployeeId
        };
    }
}
