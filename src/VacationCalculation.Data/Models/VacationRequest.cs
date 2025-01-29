using System;
using System.Collections.Generic;

namespace VacationCalculation.Data.Models;

public partial class VacationRequest
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly? ApplicationDate { get; set; }

    public int RequestedDays { get; set; }

    public string Status { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<HolidayDate> HolidayDates { get; set; } = new List<HolidayDate>();
}
