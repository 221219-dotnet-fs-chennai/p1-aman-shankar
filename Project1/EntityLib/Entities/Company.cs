using System;
using System.Collections.Generic;

namespace EntityLib.Entities;

public partial class Company
{
    public int CId { get; set; }

    public string CompanyId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? Industry { get; set; }

    public string? Duration { get; set; }

    public virtual User CompanyNavigation { get; set; } = null!;
}
