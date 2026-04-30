using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1"));
        app.MapControllers();

        if (Array.Exists(args, arg => string.Equals(arg, "--generate-client", StringComparison.OrdinalIgnoreCase)))
        {
            // Corrected: start the API first, then read its Swagger JSON and write ApiClient.cs in this folder.
            await app.StartAsync();
            await ClientGenerator.GenerateClientAsync("http://localhost:5203/swagger/v1/swagger.json", "ApiClient.cs");
            await app.StopAsync();
            return;
        }

        app.Run();
    }
}
