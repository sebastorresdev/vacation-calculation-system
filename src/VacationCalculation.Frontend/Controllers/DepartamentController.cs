using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Frontend.Mappings;
using VacationCalculation.Frontend.Models.Departament;

namespace VacationCalculation.Frontend.Controllers;

[Authorize]
public class DepartamentController(IDepartamentService departamentService) : Controller
{
    private readonly IDepartamentService _departamentService = departamentService;

    public async Task<IActionResult> ListDepartament()
    {
        var departaments = await _departamentService.GetAllDepartamentsAsync();

        return View(departaments.Select(d => d.ToViewModel()));
    }

    // Create action method 
    public IActionResult CreateDepartament()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartament(CreateDepartamentViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await _departamentService.CreateDepartamentAsync(viewModel.ToDepartament());

        return RedirectToAction(nameof(ListDepartament));
    }

    // Update action method
    public async Task<IActionResult> EditDepartament(int id)
    {
        var departament = await _departamentService.GetDepartamentByIdAsync(id);

        if (departament == null)
        {
            return RedirectToAction(nameof(ListDepartament));
        }

        return View(departament.ToUpdateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> EditDepartament(UpdateDepartamentViewModel viewModel)
    {
        if(!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await _departamentService.UpdateDepartamentAsync(viewModel.ToDepartament());

        return RedirectToAction(nameof(ListDepartament));
    }

    // Delete action method
    [HttpPost]
    public async Task<IActionResult> DeleteDepartament(int id)
    {
        await _departamentService.DeleteDepartamentAsync(id);

        return RedirectToAction(nameof(ListDepartament));
    }
}
