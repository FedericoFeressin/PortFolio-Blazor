using PortFolio_Blazor.Models;
using System.Text.Json;

namespace PortFolio_Blazor.Services;

public sealed class ProjectsService(IWebHostEnvironment env)
{
    private List<Project>? cache;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<List<Project>> GetProjectsAsync(CancellationToken ct = default)
    {
        if (cache is not null)
        {
            return cache;
        }

        var path = Path.Combine(env.WebRootPath, "data", "projects.json");
        if (!File.Exists(path))
        {
            cache = new();
            return cache;
        }

        var json = await File.ReadAllTextAsync(path, ct);
        var items = JsonSerializer.Deserialize<List<Project>>(json, JsonOptions) ?? new List<Project>();

        cache = items
            .Where(p => !string.IsNullOrWhiteSpace(p.Id))
            .ToList();
        return cache;
    }
}
