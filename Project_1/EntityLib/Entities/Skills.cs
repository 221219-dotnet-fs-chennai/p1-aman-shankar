namespace EntityLib.Entities;

public partial class Skills
{
    public int SId { get; set; }

    public string SkillId { get; set; } = null!;

    public string SkillName { get; set; } = null!;

    public virtual User SkillNavigation { get; set; } = null!;
}
