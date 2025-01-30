using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.Departament;

public class CreateDepartamentViewModel
{
    [Required(ErrorMessage = "El nombre del departamento es requerido")]
    public required string Name { get; set; }
}
