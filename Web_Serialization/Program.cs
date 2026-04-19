using System.Text.Json;
using System.Xml.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

var SamplePerson = new Person
{
    UserName = "John Doe",
    UserAge = 30,
    UserEmail = "john.doe@example.com"
};
app.MapGet("/", () => "Am root");
app.MapGet("/person", () => SamplePerson);
app.MapGet("/manual-json",() =>
{
    var jsonString = JsonSerializer.Serialize(SamplePerson);
    return TypedResults.Text(jsonString, "application/json");
});

// if you want to customize the json output, you can create a new JsonSerializerOptions and pass it to the Serialize method
app.MapGet("/custom-serializer",() =>
{
    var Option = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };
    var customJsonString = JsonSerializer.Serialize(SamplePerson, Option);
    return TypedResults.Text(customJsonString, "application/json");
});

// if you just want to send json use below code, it will automatically serialize the object to json and set the content type to application/json
app.MapGet("/me", () =>
{
    return TypedResults.Json(SamplePerson);
});

// use json by default
app.MapGet("/auto", () =>
{
    return SamplePerson;
});

// use if u want to send xml, you can use the XmlSerializer to serialize the object to xml and return it as a string with the content type set to application/xml
app.MapGet("/xml", () =>
{
    var xmlSerializer = new XmlSerializer(typeof(Person));
    using var stringWriter = new StringWriter();
    xmlSerializer.Serialize(stringWriter, SamplePerson);
    var xmlString = stringWriter.ToString();
    return TypedResults.Text(xmlString, "application/xml"); 

});


app.Run();

/* record type is a reference type that provides built-in functionality for encapsulating data.
    It is immutable by default, meaning that once an instance of a record is created, its properties cannot be changed. 
    This makes records ideal for representing data that should not be modified after creation, 
    such as configuration settings or data transfer objects. Records also provide value-based equality, 
    which means that two record instances are considered equal if their properties have the same values, 
    regardless of whether they are the same instance in memory. 
    This makes records useful for scenarios where you want to compare data based on its content rather than its reference.
    In contrast, a class is a reference type that can be mutable or immutable, depending on how it is defined.
    Classes do not provide built-in value-based equality, so you would need to override the Equals
    method to achieve similar functionality. Classes are more flexible than records and can be used for a wider range of scenarios,
    but they require more boilerplate code to achieve the same level of functionality as records.
*/
public class Person
{
    required public string UserName { get; set; }
    required public int UserAge { get; set; }
    required public string UserEmail { get; set; }
}   