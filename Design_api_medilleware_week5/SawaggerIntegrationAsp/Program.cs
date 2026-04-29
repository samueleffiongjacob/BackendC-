using Microsoft.AspNetCore.OpenApi;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
var builder = WebApplication.CreateBuilder(args);

// an api explorer is a tool that allows you to explore your api endpoints and test them out
builder.Services.AddEndpointsApiExplorer();
// swagger gen is a tool that allows you to generate swagger documentation for your api endpoints use the AddEndpointsApiExplorer method to add the api explorer service to your application and then use the AddSwaggerGen method to add the swagger gen service to your application
builder.Services.AddSwaggerGen();
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog { Name = "Tech Blog", Title = "Tech Blog" , Body = "This is a tech blog."  },
    new Blog { Name = "Travel Blog", Title = "Travel Blog" , Body = "This is a travel blog." },
    new Blog { Name = "Food Blog", Title = "Food Blog" , Body = "This is a food blog." }
};

// so that we don't have to use swagger in production we can use the IsDevelopment method to check if the application is running in development mode and only use swagger if it is
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "I am root").ExcludeFromDescription();

app.MapGet("/blogs/{id}", Results<Ok<Blog>,NotFound>(int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return TypedResults.NotFound();
    }
    else
    {
        return TypedResults.Ok(blogs[id]);
    }
}).WithName("GetBlogById")
.WithOpenApi();

app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return TypedResults.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.Run();

public class Blog
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}