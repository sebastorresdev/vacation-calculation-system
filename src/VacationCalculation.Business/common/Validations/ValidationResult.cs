using VacationCalculation.Business.common.utils;

namespace VacationCalculation.Business.common.Validations;
public class ValidationResult
{
    public bool IsValid => _errors.Count == 0;

    protected List<string> _errors;

    public Error Errors => Error.Validation("Error.Validation", "Errores de validacion", new Dictionary<string, List<string>> { { "Errors", _errors } });

    public ValidationResult(List<string> errors)
    {
        _errors = errors ?? [];
    }

    public void AddError(string error)
    {
        _errors.Add(error);
    }
}
