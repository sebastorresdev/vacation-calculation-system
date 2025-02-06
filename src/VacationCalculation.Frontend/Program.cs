using Microsoft.EntityFrameworkCore;
using VacationCalculation.Business.common.Interfaces;
using VacationCalculation.Business.Services;
using VacationCalculation.Data.Data;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Configurar autenticación con cookies
    builder.Services.AddAuthentication("CookieAuth")
        .AddCookie("CookieAuth", options =>
        {
            options.LoginPath = "/Login"; // Ruta a la página de login
            options.AccessDeniedPath = "/Home/Privacy"; // Ruta a la página de acceso denegado
        });

    builder.Services.AddAuthorization();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<VacationDbContext>(option =>
    {
        option.UseSqlServer(connectionString);
    });

    // Add services dependency injection
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
    builder.Services.AddScoped<IEmployeeTypeService, EmployeTypeService>();
    builder.Services.AddScoped<IDepartamentService, DepartamentService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<ILoginService, LoginService>();
    
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    // Habilitar autenticación y autorización
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.Run();

}