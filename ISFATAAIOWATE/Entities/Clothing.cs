using System;
using System.Collections.Generic;

namespace ISFATAAIOWATE.Entities;

public partial class Clothing
{
    public int ClothingId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Sizes { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? SupplierInfo { get; set; }

    public virtual ICollection<EmployeeClothing> EmployeeClothings { get; set; } = new List<EmployeeClothing>();
}
