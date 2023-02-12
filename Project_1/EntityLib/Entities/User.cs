using System;
using System.Collections.Generic;

namespace EntityLib.Entities;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Pincode { get; set; }

    public string? Website { get; set; }

    public string? MobileNumber { get; set; }

    public string? AboutMe { get; set; }

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual ICollection<EducationDetail> EducationDetails { get; } = new List<EducationDetail>();

    public virtual ICollection<Skills> Skills { get; } = new List<Skills>();
}
