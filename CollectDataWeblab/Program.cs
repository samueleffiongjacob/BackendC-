using CollectDataWeblab.Middleware;
using CollectDataWeblab.Routing;
using CollectDataWeblab.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserService, InMemoryUserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<Usermiddleware>();

app.MapGet("/", () => "CollectDataWeblab is running");
app.MapControllers();
app.MapUserRoute();

app.Run();
