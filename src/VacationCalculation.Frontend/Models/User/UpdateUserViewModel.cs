using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.User;

public class UpdateUserViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "El rol es requerido")]
    public int RoleId { get; set; }

    public int? EmployeeId { get; set; }
}
