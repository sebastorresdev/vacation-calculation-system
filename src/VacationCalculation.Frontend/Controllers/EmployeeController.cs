using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Frontend.Mappings;
using VacationCalculation.Frontend.Models.Employee;

namespace VacationCalculation.Frontend.Controllers;
[Authorize]
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

        return View(employees.Select(e => e.ToViewModel()));
    }

    // Create action method
    public async Task<IActionResult> CreateEmployee()
    {
        await LoadDepartamentsAndEmployeeTypes();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel employeeViewModel)
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartamentsAndEmployeeTypes();
            return View(nameof(CreateEmployee), employeeViewModel);
        }

        await _employeeService.CreateEmployeeAsync(employeeViewModel.ToEmployee());

        return RedirectToAction(nameof(ListEmployees));
    }

    // Edit action method
    public async Task<IActionResult> EditEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
        {
            return RedirectToAction(nameof(ListEmployees));
        }

        await LoadDepartamentsAndEmployeeTypes();
        return View(employee.ToUpdateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> EditEmployee(UpdateEmployeeViewModel employeeViewModel)
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartamentsAndEmployeeTypes();
            return View(nameof(EditEmployee), employeeViewModel);
        }
        var result = await _employeeService.UpdateEmployeeAsync(employeeViewModel.ToEmployee());

        if(result.IsFailure)
        {
            if (result.Error?.Metadatos?.ContainsKey("Errors") == true)
            {
                ViewBag.Errors = result.Error.Metadatos["Errors"];
            }
            await LoadDepartamentsAndEmployeeTypes();
            return View(nameof(EditEmployee), employeeViewModel);
        }

        return RedirectToAction(nameof(ListEmployees));
    }

    // Delete action method
    [HttpPost]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return RedirectToAction(nameof(ListEmployees));
    }

    private async Task LoadDepartamentsAndEmployeeTypes()
    {
        ViewBag.Departaments = new SelectList(await _departamentService.GetAllDepartamentsAsync(), "Id", "Name");
        ViewBag.EmployeeTypes = new SelectList(await _employeeTypeService.GetAllEmployeeTypesAsync(), "Id", "Name");
    }
}
