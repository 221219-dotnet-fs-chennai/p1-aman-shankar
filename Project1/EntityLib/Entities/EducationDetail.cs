using System;
using System.Collections.Generic;

namespace EntityLib.Entities;

public partial class EducationDetail
{
    public int EId { get; set; }

    public string EducationId { get; set; } = null!;

    public string EducationName { get; set; } = null!;

    public string? InstituteName { get; set; }

    public string? Grade { get; set; }

    public string? Duration { get; set; }

    public virtual User Education { get; set; } = null!;
}
