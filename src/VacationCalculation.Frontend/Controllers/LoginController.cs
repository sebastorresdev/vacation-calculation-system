using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VacationCalculation.Business.common.Contracts;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Frontend.Models.Login;

namespace VacationCalculation.Frontend.Controllers;

public class LoginController(ILoginService loginService) : Controller
{
    private readonly ILoginService _loginService = loginService;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(nameof(Index), loginViewModel);
        }

        var result = await _loginService.LoginAsync(loginViewModel.Username, loginViewModel.Password);

        if (result.IsSuccess)
        {
            await CreateSession(result.Value!);
            return RedirectToAction(nameof(Index), "Home");
        }

        return View(nameof(Index), loginViewModel);
    }

    private async Task CreateSession(LoginResponse loginResponse)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginResponse.Name),
            new Claim(ClaimTypes.Role, loginResponse.Role) // Asignar un rol si es necesario
        };

        loginResponse.Permissions.ForEach(permission =>
        {
            claims.Add(new Claim("permissions", permission));
        });

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true // Mantener la sesión abierta
        };

        await HttpContext.SignInAsync(
            "CookieAuth",
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        
    }
}