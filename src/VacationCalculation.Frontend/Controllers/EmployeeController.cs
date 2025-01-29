using Microsoft.AspNetCore.Mvc;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Frontend.Controllers;
public class EmployeeController(IEmployeeService employeeService) : Controller
{
    private readonly IEmployeeService _employeeService = employeeService;

    // Index action method
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View("EmployeeIndex", employees);
    }

    public IActionResult CreateView()
    {
        return View("EmployeeCreate");
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        if(!ModelState.IsValid)
        {
            return View("EmployeeCreate", employee);
        }

        await _employeeService.CreateEmployeeAsync(employee);

        return RedirectToAction(nameof(Index));
    }
}
