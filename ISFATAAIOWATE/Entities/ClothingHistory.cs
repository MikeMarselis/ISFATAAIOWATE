using System;
using System.Collections.Generic;

namespace ISFATAAIOWATE.Entities;

public partial class ClothingHistory
{
    public int OrderId { get; set; }

    public string? Lfsemployee { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public string? ClothingName { get; set; }
}
