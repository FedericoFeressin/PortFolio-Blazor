using System.Text.Json;
using PortFolio_Blazor.Models;

namespace PortFolio_Blazor.Services;

public sealed class ContactService(IWebHostEnvironment env, ILogger<ContactService> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = false
    };

    public async Task SaveAsync(ContactFormModel model, CancellationToken ct = default)
    {
        var now = DateTimeOffset.UtcNow;
        var record = new
        {
            createdAtUtc = now,
            name = model.Name.Trim(),
            email = model.Email.Trim(),
            message = model.Message.Trim(),
            userAgent = "",
        };

        var appData = Path.Combine(env.ContentRootPath, "App_Data");
        Directory.CreateDirectory(appData);
        var path = Path.Combine(appData, "contact-messages.jsonl");

        var line = JsonSerializer.Serialize(record, JsonOptions);
        await File.AppendAllTextAsync(path, line + Environment.NewLine, ct);

        logger.LogInformation("Contact message stored at {Path}", path);
    }
}
