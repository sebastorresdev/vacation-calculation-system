using Microsoft.AspNetCore.Mvc;
using VacationCalculation.Business.Interfaces;
using VacationCalculation.Frontend.Mappings;
using VacationCalculation.Frontend.Models.EmployeeType;

namespace VacationCalculation.Frontend.Controllers;
public class EmployeeTypeController(IEmployeeTypeService employeeTypeService) : Controller
{
    private readonly IEmployeeTypeService _employeeTypeService = employeeTypeService;

    public async Task<IActionResult> ListEmployeeType()
    {
        var EmployeeTypes = await _employeeTypeService.GetAllEmployeeTypesAsync();

        return View(EmployeeTypes.Select(t => t.ToViewModel()));
    }

    // Create action method 
    public IActionResult CreateEmployeeType()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployeeType(CreateEmployeeTypeViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await _employeeTypeService.CreateEmployeeTypeAsync(viewModel.ToEmployeeType());

        return RedirectToAction(nameof(ListEmployeeType));
    }

    // Update action method
    public async Task<IActionResult> EditEmployeeType(int id)
    {
        var EmployeeType = await _employeeTypeService.GetEmployeeTypeByIdAsync(id);

        if(EmployeeType == null)
        {
            return RedirectToAction(nameof(ListEmployeeType));
        }

        return View(EmployeeType.ToUpdateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> EditEmployeeType(UpdateEmployeeTypeViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await _employeeTypeService.UpdateEmployeeTypeAsync(viewModel.ToEmployeeType());

        return RedirectToAction(nameof(ListEmployeeType));
    }

    // Delete action method
    [HttpPost]
    public async Task<IActionResult> DeleteEmployeeType(int id)
    {
        await _employeeTypeService.DeleteEmployeeTypeAsync(id);

        return RedirectToAction(nameof(ListEmployeeType));
    }
}
