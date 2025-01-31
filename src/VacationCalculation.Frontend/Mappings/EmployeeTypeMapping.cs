using VacationCalculation.Data.Models;
using VacationCalculation.Frontend.Models.EmployeeType;

namespace VacationCalculation.Frontend.Mappings;

public static class EmployeeTypeMapping
{
    public static EmployeeType ToEmployeeType(this CreateEmployeeTypeViewModel viewModel)
    {
        return new EmployeeType
        {
            Name = viewModel.Name,
            DaysPerYear = viewModel.DaysPerYear
        };
    }

    public static EmployeeType ToEmployeeType(this UpdateEmployeeTypeViewModel viewModel)
    {
        return new EmployeeType
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            DaysPerYear = viewModel.DaysPerYear,
        };
    }

    public static EmployeeTypeViewModel ToViewModel(this EmployeeType EmployeeType)
    {
        return new EmployeeTypeViewModel
        {
            Id = EmployeeType.Id,
            Name = EmployeeType.Name,
            DaysPerYear = EmployeeType.DaysPerYear
        };
    }

    public static UpdateEmployeeTypeViewModel ToUpdateViewModel(this EmployeeType EmployeeType)
    {
        return new UpdateEmployeeTypeViewModel
        {
            Id = EmployeeType.Id,
            Name = EmployeeType.Name,
            DaysPerYear = EmployeeType.DaysPerYear
        };
    }
}
