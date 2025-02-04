using Microsoft.AspNetCore.Mvc;

namespace VacationCalculation.Frontend.Controllers;
public class UserController : Controller
{
    public IActionResult ListUser()
    {
        return View();
    }
}
