using System;
using System.Collections.Generic;

namespace ISFATAAIOWATE.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? Status { get; set; }

    public int? ClothingId { get; set; }

    public virtual Clothing? Clothing { get; set; }

    public virtual Employee? Employee { get; set; }
}
