using  Newtonsoft.Json;

public class Product
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public List<string>? Tags { get; set; }
}

public class Samuel : Product
{
    //public string Description { get; set; }
}
public class Program
{
    public static void Main()
    {
        // Deserialization converts incoming JSON text into a C# object so we can access data with properties.
        string json = "{\"Name\": \"Laptop\", \"Price\": 999.99, \"Tags\": [\"Electronics\", \"Computers\"]}";

        // JsonConvert.DeserializeObject<T>() maps JSON fields to the Product class fields.
        Product product = JsonConvert.DeserializeObject<Product>(json);

        // Print the deserialized object values.
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine("Tags: " + string.Join(", ", product.Tags));


        Samuel newProduct = new Samuel
        {
            Name = "Smartphone",
            Price = 499.99m,
            Tags = new List<string> { "Electronics", "Mobile" }
        };

        // Serialization converts a C# object into JSON so it can be sent to APIs, saved to files, or transferred over a network.
        // JsonConvert.SerializeObject() creates a JSON string from the object.
        string newJson = JsonConvert.SerializeObject(newProduct, Formatting.Indented);
        Console.WriteLine($"Serialized JSON: \n{newJson}");
    }

   }