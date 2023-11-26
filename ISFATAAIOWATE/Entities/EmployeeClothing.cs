using System;
using System.Collections.Generic;

namespace ISFATAAIOWATE.Entities;

public partial class EmployeeClothing
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? ClothingId { get; set; }

    public virtual Clothing? Clothing { get; set; }

    public virtual Employee? Employee { get; set; }
}
