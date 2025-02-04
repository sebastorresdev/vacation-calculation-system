using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.User;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "El nombre es requerido")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    [MaxLength(10, ErrorMessage = "El contraseña no puede tener más de 10 caracteres")]
    [MinLength(6, ErrorMessage = "El contraseña no puede tener menos de 6 caracteres")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required(ErrorMessage = "El rol es requerido")]
    public int RoleId { get; set; }

    public int? EmployeeId { get; set; }
}
