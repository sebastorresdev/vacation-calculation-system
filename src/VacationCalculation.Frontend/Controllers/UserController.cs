using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Frontend.Mappings;
using VacationCalculation.Frontend.Models.User;

namespace VacationCalculation.Frontend.Controllers;
[Authorize]
public class UserController(IUserService userService, IEmployeeService employeeService) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<IActionResult> ListUser()
    {
        var users = await _userService.GetUsersAsync();
        return View(users.Select(u => u.ToViewModel()));
    }

    public async Task<IActionResult> CreateUser()
    {
        await LoadRolesAndEmployees();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel newUser)
    {
        if(!ModelState.IsValid)
        {
            await LoadRolesAndEmployees();
            return View(newUser);
        }


        var result = await _userService.CreateUserAsync(newUser.ToUser());

        if (result.IsSuccess)
            return RedirectToAction(nameof(ListUser));

        ViewBag.Error = result.Error!.Description;
        await LoadRolesAndEmployees();
        return View(newUser);
    }

    public async Task<IActionResult> EditUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if(user == null)
        {
            return NotFound();
        }
       
        await LoadRolesAndEmployees();
        var u = user.ToUpdateViewModel();
        return View(u);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(UpdateUserViewModel editUser)
    {
        if(!ModelState.IsValid)
        {
            await LoadRolesAndEmployees();
            return View(editUser);
        }

        var result = await _userService.UpdateUserAsync(editUser.ToUser());

        if(result.IsSuccess)
            return RedirectToAction(nameof(ListUser));

        ViewBag.Error = result.Error!.Description;
        await LoadRolesAndEmployees();
        return View(editUser);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _userService.DeleteUserAsync(id);
        return RedirectToAction(nameof(ListUser));
    }

    private async Task LoadRolesAndEmployees()
    {
        ViewBag.Roles = new SelectList(await _userService.GetRolesAsync(), "Id", "Name");
        ViewBag.Employees = new SelectList(await _employeeService.GetAllEmployeesAsync(), "Id", "Name");
    }
}
