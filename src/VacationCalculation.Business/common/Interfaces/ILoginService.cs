using VacationCalculation.Business.common.Contracts;
using VacationCalculation.Business.common.utils;

namespace VacationCalculation.Business.common.Interfaces;

public interface ILoginService
{
    Task<Result<LoginResponse>> LoginAsync(string username, string password);
}