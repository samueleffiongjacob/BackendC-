using System.Text.Json;
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Am Root!");

// Decerilization example
app.MapPost("/auto", (Person PersonFromClient) =>
{
    return TypedResults.Ok(PersonFromClient);
});

// Manual deserialization example
app.MapPost("/json", HandleJsonDeserialization);

// Manual deserialization with error handling
app.MapPost("/custom-options", HandleCustomOptions);

// XML deserialization
app.MapPost("/xml", HandleXmlDeserialization);

app.Run();

// Handler methods
async Task<IResult> HandleJsonDeserialization(HttpContext context)
{
    var personFromClient = await context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Ok(personFromClient);
}

async Task<IResult> HandleCustomOptions(HttpContext context)
{
    try
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        var personFromClient = await context.Request.ReadFromJsonAsync<Person>(options);
        return TypedResults.Ok(personFromClient);
    }
    catch (JsonException ex)
    {
        return TypedResults.BadRequest(new { error = "Invalid JSON format", details = ex.Message });
    }
}

async Task<IResult> HandleXmlDeserialization(HttpContext context)
{
    try
    {
        using var reader = new StreamReader(context.Request.Body);
        var xmlContent = await reader.ReadToEndAsync();
        var serializer = new XmlSerializer(typeof(Person));
        using var stringReader = new StringReader(xmlContent);
        var personFromClient = (Person?)serializer.Deserialize(stringReader);
        return TypedResults.Ok(personFromClient);
    }
    catch (Exception ex)
    {
        return TypedResults.BadRequest(new { error = "Invalid XML format", details = ex.Message });
    }
}

public class Person
{
    required public string UserName { get; set; }
    public int? UserAge { get; set; }
}