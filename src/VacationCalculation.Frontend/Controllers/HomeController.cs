using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Frontend.Models;

namespace VacationCalculation.Frontend.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", "About.txt");

        if (!System.IO.File.Exists(filePath))
        {
            _logger.LogWarning("El archivo acerca-de.txt no se encontró en {Path}", filePath);
            return NotFound("El archivo acerca-de.txt no fue encontrado.");
        }

        string content = System.IO.File.ReadAllText(filePath);

        return View("About", model: content);
    }   
}
