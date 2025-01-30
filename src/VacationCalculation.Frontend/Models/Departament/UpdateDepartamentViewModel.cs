using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.Departament;

public class UpdateDepartamentViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de departamento es requerido")]
    public required string Name { get; set; }
}
