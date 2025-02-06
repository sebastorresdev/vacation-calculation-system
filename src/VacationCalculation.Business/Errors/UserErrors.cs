using VacationCalculation.Business.common.utils;

namespace VacationCalculation.Business.Errors;

public static class UserErrors
{
    public static Error UserNotFound() => Error.NoFound("user.notfound", $"Usuario no encontrado");
    public static Error UserExisting(string name) => Error.Conflict("user.conflict", $"Ya existe un nombre de usuario para {name}");
}