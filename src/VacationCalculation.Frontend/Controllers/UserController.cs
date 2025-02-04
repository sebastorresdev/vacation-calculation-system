using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Data.Models;
using VacationCalculation.Frontend.Mappings;
using VacationCalculation.Frontend.Models.User;

namespace VacationCalculation.Frontend.Controllers;
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
        var roles = await _userService.GetRolesAsync();
        var employees = await _employeeService.GetAllEmployeesAsync();

        ViewBag.Roles = new SelectList(roles, "Id", "Name");
        ViewBag.Employees = new SelectList(employees, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel newUser)
    {
        if (!ModelState.IsValid)
        {
            var roles = await _userService.GetRolesAsync();
            var employees = await _employeeService.GetAllEmployeesAsync();

            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            return View(newUser);
        }

        await _userService.CreateUserAsync(newUser.ToUser());
        return RedirectToAction(nameof(ListUser));
    }

    public async Task<IActionResult> EditUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        var roles = await _userService.GetRolesAsync();
        var employees = await _employeeService.GetAllEmployeesAsync();
        ViewBag.Roles = new SelectList(roles, "Id", "Name");
        ViewBag.Employees = new SelectList(employees, "Id", "Name");

        var u = user.ToUpdateViewModel();
        return View(u);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(UpdateUserViewModel editUser)
    {
        if (!ModelState.IsValid)
        {
            var roles = await _userService.GetRolesAsync();
            var employees = await _employeeService.GetAllEmployeesAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            ViewBag.Employees = new SelectList(employees, "Id", "Name");
            return View(editUser);
        }
        await _userService.UpdateUserAsync(editUser.ToUser());
        return RedirectToAction(nameof(ListUser));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return RedirectToAction(nameof(ListUser));
    }
}
