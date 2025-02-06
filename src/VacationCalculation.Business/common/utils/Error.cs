namespace VacationCalculation.Business.common.utils;

public class Error
{
    public string Type { get; }
    public string Code { get; }
    public string Description { get; }

    private Error(string type, string code, string description)
    {
        Type = type;
        Code = code;
        Description = description;
    }

    public static Error Failure(string code, string message) => new ("Failure", code, message);
    public static Error NoFound(string code, string message) => new ("NotFound", code, message);
    public static Error Conflict(string code, string message) => new ("Conflict", code, message);
    public static Error Unauthorized(string code, string message) => new ("Unauthorized", code, message);
    public static Error Forbidden(string code, string message) => new ("Forbidden", code, message);
    public static Error Unexpected(string code, string message) => new ("Unexpected", code, message);
}