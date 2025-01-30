using VacationCalculation.Data.Models;
using VacationCalculation.Frontend.Models.Departament;

namespace VacationCalculation.Frontend.Mappings;

public static class DepartamentMapping
{
    public static Departament ToDepartament(this CreateDepartamentViewModel viewModel)
    {
        return new Departament
        {
            Name = viewModel.Name
        };
    }

    public static Departament ToDepartament(this UpdateDepartamentViewModel viewModel)
    {
        return new Departament 
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };
    }

    public static DepartamentViewModel ToViewModel(this Departament departament)
    {
        return new DepartamentViewModel
        {
            Id = departament.Id,
            Name = departament.Name
        };
    }

    public static UpdateDepartamentViewModel ToUpdateViewModel(this Departament departament)
    {
        return new UpdateDepartamentViewModel
        {
            Id = departament.Id,
            Name = departament.Name
        };
    }
}
