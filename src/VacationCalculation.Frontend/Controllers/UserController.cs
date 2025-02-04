using Microsoft.AspNetCore.Mvc;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Frontend.Mappings;

namespace VacationCalculation.Frontend.Controllers;
public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;

    public async Task<IActionResult> ListUser()
    {
        var users = await _userService.GetUsersAsync();
        return View(users.Select(u => u.ToViewModel()));
    }
}
