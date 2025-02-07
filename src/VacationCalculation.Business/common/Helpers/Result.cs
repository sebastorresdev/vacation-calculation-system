namespace VacationCalculation.Business.common.utils;

public readonly struct Result<TModel>
{
    public TModel? Value { get; }
    public Error? Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TModel model)
    {
        Value = model;
        Error = default;
        IsSuccess = true;
    }

    private Result(Error error)
    {
        Value = default;
        Error = error;
        IsSuccess = false;
    }

    public static implicit operator Result<TModel>(TModel model) => new (model);
    public static implicit operator Result<TModel>(Error error) => new (error);

    public TResult Match<TResult>(Func<TModel, TResult> onSuccess, Func<Error, TResult> onError)
        => IsSuccess ? onSuccess(Value!) : onError(Error!);
}