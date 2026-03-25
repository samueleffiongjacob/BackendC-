var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/download", () => "This is a file download example.");
app.MapGet("/time", () => DateTime.Now.ToString("T"));
app.MapGet("/greet/{name}", (string name) => $"Hello, {name}!");
app.MapPut("/", () => new { Message = "Welcome to the minimal API!" });
app.MapDelete("/delete", () => "This is a delete endpoint.");
app.MapPost("/", () => new { Message = "This is a post endpoint." });
app.Run();
