namespace VacationCalculation.Frontend.Models.User;

public class UserViewModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public required string Departament { get; set; }
}
