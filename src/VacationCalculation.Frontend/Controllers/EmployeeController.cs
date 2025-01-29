using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Data.Models;

namespace VacationCalculation.Frontend.Controllers;
public class EmployeeController(
    IEmployeeService employeeService,
    IDepartamentService departamentService,
    IEmployeeTypeService employeeTypeService
    ) : Controller
{
    private readonly IEmployeeService _employeeService = employeeService;
    private readonly IDepartamentService _departamentService = departamentService;
    private readonly IEmployeeTypeService _employeeTypeService = employeeTypeService;

    // Index action method
    public async Task<IActionResult> ListEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View(employees);
    }

    public async Task<IActionResult> CreateEmployee()
    {
        var employeeTypes = await _employeeTypeService.GetAllEmployeeTypesAsync();
        var departaments = await _departamentService.GetAllDepartamentsAsync();

        ViewBag.Departaments = new SelectList(departaments, "Id", "Name");
        ViewBag.EmployeeTypes = new SelectList(employeeTypes, "Id", "Name");

        return View();
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
