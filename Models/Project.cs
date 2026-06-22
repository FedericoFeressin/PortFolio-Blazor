namespace PortFolio_Blazor.Models;

public sealed class Project
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }

    public string? LiveUrl { get; init; }
    public required string RepoUrl { get; init; }

    public string? ImageUrl { get; init; }
    public string? Badge { get; init; }

    public List<string> Technologies { get; init; } = new();

    public string? AccentA { get; init; }
    public string? AccentB { get; init; }
}
