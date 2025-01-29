using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class HolidayDate
{
    public int Id { get; set; }

    public int VacationRequestId { get; set; }

    public DateOnly ApplicationDate { get; set; }

    public string Type { get; set; } = null!;

    public virtual VacationRequest VacationRequest { get; set; } = null!;
}
