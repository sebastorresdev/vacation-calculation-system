using System.ComponentModel.DataAnnotations;

namespace VacationCalculation.Frontend.Models.Employee;

public class UpdateEmployeeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "El apellido es requerido")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener mas de 50 caracteres")]
    public required string PaternalSurname { get; set; }

    public string? MaternalSurname { get; set; }

    [Required(ErrorMessage = "El correo electronico es requerido")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "La fecha de ingreso es requerido")]
    [DataType(DataType.Date, ErrorMessage = "El campo no es una fecha válida")]
    public DateTime DateEntry { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es requerido")]
    [DataType(DataType.Date, ErrorMessage = "El campo no es una fecha válida")]
    public DateTime Birthday { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El empleado no puede tener un ID negativo.")]
    public int DepartamentId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El empleado no puede tener un ID negativo.")]
    public int EmployeeTypeId { get; set; }
}
