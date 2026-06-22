namespace PortFolio_Blazor.Models;

public sealed class SiteProfile
{
    public string Name { get; init; } = "Federico Feressin";
    public string Role { get; init; } = "Full Stack Developer";
    public string Tagline { get; init; } = "Construyo experiencias web modernas, rápidas y escalables.";
    public string ShortBio { get; init; } = "";
    public string LongBio { get; init; } = "";
    public string Location { get; init; } = "Remoto / Argentina";
    public string Availability { get; init; } = "Disponible para proyectos";
    public string Email { get; init; } = "fedeferessin2001@gmail.com";
    public string AvatarUrl { get; init; } = "";
    public SocialLinksModel Social { get; init; } = new();
    public List<SkillGroup> SkillGroups { get; init; } = new();
    public List<ExperienceItem> Experience { get; init; } = new();
    public List<string> Highlights { get; init; } = new();
}

public sealed class SocialLinksModel
{
    public string LinkedIn { get; init; } = "https://www.linkedin.com";
    public string GitHub { get; init; } = "https://github.com";
    public string? Twitter { get; init; }
    public string? Portfolio { get; init; }
}

public sealed class SkillGroup
{
    public string Category { get; init; } = "";
    public int Level { get; init; }
    public string Label { get; init; } = "";
    public List<string> Items { get; init; } = new();
}

public sealed class ExperienceItem
{
    public string Period { get; init; } = "";
    public string Title { get; init; } = "";
    public string Company { get; init; } = "";
    public string Description { get; init; } = "";
}
