using System.Text.Json;
using PortFolio_Blazor.Models;

namespace PortFolio_Blazor.Services;

public sealed class ProfileService(IWebHostEnvironment env)
{
    private SiteProfile? cache;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<SiteProfile> GetProfileAsync(CancellationToken ct = default)
    {
        if (cache is not null)
        {
            return cache;
        }

        var path = Path.Combine(env.WebRootPath, "data", "profile.json");
        if (!File.Exists(path))
        {
            cache = new SiteProfile();
            return cache;
        }

        var json = await File.ReadAllTextAsync(path, ct);
        cache = JsonSerializer.Deserialize<SiteProfile>(json, JsonOptions) ?? new SiteProfile();
        return cache;
    }
}
