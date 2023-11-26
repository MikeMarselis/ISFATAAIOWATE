using System;
using System.Collections.Generic;

namespace ISFATAAIOWATE.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int PositionId { get; set; }

    public string Department { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? SecondName { get; set; }

    public string? Lfs { get; set; }

    public virtual ICollection<EmployeeClothing> EmployeeClothings { get; set; } = new List<EmployeeClothing>();

    public virtual Position Position { get; set; } = null!;
}
