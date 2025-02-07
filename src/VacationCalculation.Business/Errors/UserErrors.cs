using VacationCalculation.Business.common.utils;

namespace VacationCalculation.Business.Errors;

public static class UserErrors
{
    public static Error UserNotFound() => Error.NotFound("user.notfound", $"Usuario no encontrado");
    public static Error UserExisting(string name) => Error.Conflict("user.conflict", $"Ya existe un nombre de usuario para {name}");
    public static Error UserExistingRole() => Error.Conflict("user.conflict", "No se puede asignar el role de Jefe porque ya esta asignado");
    public static Error UserEmployeeAlreadyAssigned()
        => Error.Conflict("user.conflict", "No se puede asignar el empleado porque ya esta asignado a otro usuario");
}