var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog { Title = "My FIRST POst", Body = "This is my first post" },
    new Blog { Title = "My SECOND POst", Body = "This is my second post" }
};
app.MapGet("/", () => "I am samuel in the server root!");
app.MapGet("/blogs", () => {
    return blogs;
});

app.MapGet("/blogs/{id}", (int id) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        return Results.Ok(blogs[id]);
    } 
    
});

app.MapPost("/blogs", (Blog blog) => {
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});


app.MapDelete("/blogs/{id}", (int id) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        var deletedBlog = blogs[id];
        blogs.RemoveAt(id);
        return Results.Ok(deletedBlog);
    } 
    
});

app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }  else
    {
        blogs[id] = updatedBlog;
        return Results.Ok(blogs[id]);
    } 
    
});

app.Run();  


public class Blog
{
    public string Title { get; set; }
    public string Body { get; set; }
}