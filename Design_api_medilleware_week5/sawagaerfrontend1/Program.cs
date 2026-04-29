// Automatic code generation using Swagger codegen tools.
// > Nuget add Package 
//Nswag
//Nswag.CodeGeneration.CSharp

// the above if u want to install from vscode commade plate or terminal below

// dotnet add package NSwag.Core
// dotnet add package NSwag.CodeGeneration.CSharp
//dotnet restore

// >Nuget install NSwag.CodeGeneration.CSharp -Version 13.16.0
// >dotnet add package NSwag.CodeGeneration.CSharp --version 13.16.0

// await ClientGenerator.Main(); // only run once

using System.Collections.Concurrent;
using SawaggerIntegrationAsp; 

var httpClient = new HttpClient();
var apiUrl = "http://localhost:5266";

var response = new ApiClient(apiUrl,httpClient);

//var blogs = await response.GetBlogsAsync();
try
{
    var retrievedBlog = await response.GetBlogByIdAsync(3);
    Console.WriteLine($"Name: {retrievedBlog.Name}, Title: {retrievedBlog.Title}, Body: {retrievedBlog.Body}");
}
catch (ApiException ex) when (ex.StatusCode == 404)
{
    Console.WriteLine("Blog not found.");
}

// delete 

// // post
// var blogToCreate = new Blog
// {
//     Name = "Samuel Effiong",
//     Title = "Food is live",
//     Body = "Food is Good"
// };
// await response.BlogsAsync(blogToCreate);
// below writting it manually below hard work

// App runing at http://localhost:5266

// var httpClient = new HttpClient();
// var apiUrl = "http://localhost:5266";
// var response = await httpClient.GetAsync($"{apiUrl}/blogs/0");

// // simple status print (callable anywhere)
// var statusCode = (int)response.StatusCode;
// var statusMessage = response.StatusCode.ToString();
// var statusInfo = $"{statusCode} {statusMessage}";
// //Console.WriteLine($"{statusCode} {statusMessage}");

// if (!response.IsSuccessStatusCode)
// {
//     Console.WriteLine($"{statusInfo}: Failed to retrieve blogs.\n");
//     return;
// }

// var content = await response.Content.ReadAsStringAsync();

// var options = new System.Text.Json.JsonSerializerOptions
// {
  
//    PropertyNameCaseInsensitive = true
// };

// var blog = System.Text.Json.JsonSerializer.Deserialize<Blog>(content, options);

// if (blog != null)
// {
//     Console.WriteLine($"{statusInfo}: Name: {blog.Name}, Title: {blog.Title}, Body: {blog.Body} \n ");
// }

// public class Blog
// {
//     public required string Name { get; set; }
//     public required string Title { get; set; }
//     public required string Body { get; set; }
// }
