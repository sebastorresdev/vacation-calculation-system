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

    private readonly IEnumerable<Role> _roles = userService.GetRolesAsync().Result;
    private readonly IEnumerable<Employee> _employees = employeeService.GetAllEmployeesAsync().Result;

    public async Task<IActionResult> ListUser()
    {
        var users = await _userService.GetUsersAsync();
        return View(users.Select(u => u.ToViewModel()));
    }

    public IActionResult CreateUser()
    {
        ViewBag.Roles = new SelectList(_roles, "Id", "Name");
        ViewBag.Employees = new SelectList(_employees, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel newUser)
    {
        if(!ModelState.IsValid)
        {
            ViewBag.Roles = new SelectList(_roles, "Id", "Name");
            ViewBag.Employees = new SelectList(_employees, "Id", "Name");

            return View(newUser);
        }

        try
        {
            await _userService.CreateUserAsync(newUser.ToUser());
            return RedirectToAction(nameof(ListUser));
        }
        catch(Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        ViewBag.Roles = new SelectList(_roles, "Id", "Name");
        ViewBag.Employees = new SelectList(_employees, "Id", "Name");

        return View(newUser);
    }

    public async Task<IActionResult> EditUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if(user == null)
        {
            return NotFound();
        }
       
        ViewBag.Roles = new SelectList(_roles, "Id", "Name");
        ViewBag.Employees = new SelectList(_employees, "Id", "Name");

        var u = user.ToUpdateViewModel();
        return View(u);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(UpdateUserViewModel editUser)
    {
        if(!ModelState.IsValid)
        {
            ViewBag.Roles = new SelectList(_roles, "Id", "Name");
            ViewBag.Employees = new SelectList(_employees, "Id", "Name");
            return View(editUser);
        }

        try
        {
            await _userService.UpdateUserAsync(editUser.ToUser());
            return RedirectToAction(nameof(ListUser));
        }
        catch(Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        ViewBag.Roles = new SelectList(_roles, "Id", "Name");
        ViewBag.Employees = new SelectList(_employees, "Id", "Name");
        return View(editUser);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return RedirectToAction(nameof(ListUser));
    }
}
