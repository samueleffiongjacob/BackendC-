var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) => {
    return $"User ID: {userId}, Slug: {slug}";
});

app.MapGet("/products/{id:int:min(0)}", (int id) => {
    return $"Product ID: {id}";
});


app.MapGet("/products/{id:int:min(0)}", (int id) => {
    return $"Product ID: {id}";
});

app.MapGet("/reports/{year?}/", (int? year) => {
    if (year.HasValue)
    {
        return $"Report for year: {year.Value}";
    }
    else
    {
        return "Report for all years";
    }
}); 

// define a default value for the year parameter
app.MapGet("/source/{year?}/", (int? year=2023) => {
    if (year.HasValue)
    {
        return $"Report for year: {year.Value}";
    }
    else
    {
        return "Report for all years";
    }
}); 

// catch all route to handle any unmatched routes
app.MapGet("/files/{*filepath}", (string filepath) => {
    return $"Requested file path: {filepath}";
});

//query string parameters
app.MapGet("/search", (string?q, int page =1) => {
    return $"Search query: {q} on page: {page}";    
});


// combine route parameters and query string parameters
app.MapGet("/store/{category}/{productId:int?}/{*extrapath}", (string category, string? extrapath, int? productId, bool instock = true)  => {
    return $"Product: {productId} in category: {category}, path: {extrapath}, in stock: {instock}";
});
app.Run();
