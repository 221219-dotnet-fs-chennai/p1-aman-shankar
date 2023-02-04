using System;
using System.Collections.Generic;

namespace EntityLib.Entities;

public partial class Skill
{
    public int SId { get; set; }

    public string SkillId { get; set; } = null!;

    public string SkillName { get; set; } = null!;

    public virtual User SkillNavigation { get; set; } = null!;
}
