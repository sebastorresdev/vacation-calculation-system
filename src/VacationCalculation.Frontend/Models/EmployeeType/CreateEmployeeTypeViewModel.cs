using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.EmployeeType;

public class CreateEmployeeTypeViewModel
{
    [Required(ErrorMessage = "El nombre del tipo de empleado es requerido")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "La cantidad de dias es requerido")]
    [Range(1, 30, ErrorMessage = "El rango de dias debe ser entre 1 y 30 dias")]
    public required int DaysPerYear { get; set; }
}
