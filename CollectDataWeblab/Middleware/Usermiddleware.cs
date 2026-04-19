using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using CollectDataWeblab.Model;

namespace CollectDataWeblab.Middleware;

public class Usermiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.HasStarted)
        {
            return;
        }

        if (!context.Items.TryGetValue("serialize-format", out var formatObj) ||
            !context.Items.TryGetValue("serialize-data", out var dataObj))
        {
            return;
        }

        var users = dataObj as IReadOnlyList<User> ?? [];
        var format = formatObj?.ToString()?.ToLowerInvariant();

        byte[] payload;
        string contentType;
        string extension;

        switch (format)
        {
            case "json":
                payload = JsonSerializer.SerializeToUtf8Bytes(users, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                contentType = "application/json";
                extension = "json";
                break;
            case "xml":
                var xmlSerializer = new XmlSerializer(typeof(List<User>));
                using (var writer = new StringWriter())
                {
                    xmlSerializer.Serialize(writer, users.ToList());
                    payload = Encoding.UTF8.GetBytes(writer.ToString());
                }
                contentType = "application/xml";
                extension = "xml";
                break;
            case "dat":
                payload = Encoding.UTF8.GetBytes(string.Join(Environment.NewLine,
                    users.Select(u => $"{u.Name}|{u.Email}|{u.Age}")));
                contentType = "application/octet-stream";
                extension = "dat";
                break;
            case "binary":
                using (var stream = new MemoryStream())
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
                {
                    writer.Write(users.Count);
                    foreach (var user in users)
                    {
                        writer.Write(user.Name);
                        writer.Write(user.Email);
                        writer.Write(user.Age);
                    }

                    writer.Flush();
                    payload = stream.ToArray();
                }
                contentType = "application/octet-stream";
                extension = "bin";
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Unsupported format. Use json, xml, dat, or binary.");
                return;
        }

        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = contentType;
        context.Response.Headers.ContentDisposition = $"attachment; filename=users.{extension}";
        await context.Response.Body.WriteAsync(payload);
    }
}
