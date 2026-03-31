var builder = WebApplication.CreateBuilder(args);
// middleware
builder.Services.AddHttpLogging((o) => {});
var app = builder.Build();

// app.UseRouting();
//appUseAuthentication();
//app.UseAuthorization();
//app.UseExceptionHandler();
app.Use(async (context, next) =>
{
    Console.WriteLine("Before");
    await next.Invoke();
    Console.WriteLine("After");
});
// app.UseEndpoint();

// all comment are done by order, so if you want to use authentication, you should use it before authorization, and if you want to use exception handler, you should use it before all of them.
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "Test");

app.Run();
