namespace VacationCalculation.Business.common.Validations;
public abstract class AbstractValidator<TModel>
{
    private readonly Dictionary<Func<TModel, Task<bool>>, string> _asyncRules = [];

    protected void RuleForAsync(Func<TModel, Task<bool>> predicate, string errorMessage)
    {
        _asyncRules.Add(predicate, errorMessage);
    }

    public async Task<ValidationResult> ValidateAsync(TModel entity)
    {
        var errors = new List<string>();

        foreach (var rule in _asyncRules)
        {
            if (!await rule.Key(entity))
                errors.Add(rule.Value);
        }

        return new ValidationResult(errors);
    }
}
