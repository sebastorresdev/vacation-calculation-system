namespace VacationCalculation.Business.common.Contracts;

public record LoginResponse(
    int Id,
    string Name,
    string Role,
    List<string> Permissions
);