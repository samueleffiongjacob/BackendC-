using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;



public class Program
{
    public class Person
   {
        public string UserName { get; set; }
        public int UserAge { get; set; }
    }
    
    static void Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Simulate deserialization from a binary file
        using (var fs = new FileStream("person.dat", FileMode.Open))
        using (var reader = new BinaryReader(fs))
        {
            var DeserializedPerson = new Person
            {
                UserName = reader.ReadString(),
                UserAge = reader.ReadInt32()
            };

            stopwatch.Stop();
            Console.WriteLine($"Deserialized Person: {DeserializedPerson.UserName}, Age: {DeserializedPerson.UserAge}");
            Console.WriteLine($"Time taken for Binary deserialization: {stopwatch.ElapsedMilliseconds} ms");
        }

        // Simulate deserialization in xml
        var xmlData = "<Person><UserName>John Doe</UserName><UserAge>30</UserAge></Person>";
        var xmlSerializer = new XmlSerializer(typeof(Person));

        Stopwatch stopwatch1 = Stopwatch.StartNew();
        using (var stringReader = new StringReader(xmlData))
        {
            var deserializedPerson = (Person)xmlSerializer.Deserialize(stringReader);
            stopwatch1.Stop();
            Console.WriteLine($"Deserialized Person: {deserializedPerson.UserName}, Age: {deserializedPerson.UserAge}");
            Console.WriteLine($"Time taken for XML deserialization: {stopwatch1.ElapsedMilliseconds} ms");
        }
        // Simulate deserialization in json
        var jsonData = "{\"UserName\":\"Jane Doe\",\"UserAge\":25}";
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        var deserializedJsonPerson = JsonSerializer.Deserialize<Person>(jsonData);
        stopwatch2.Stop();
        Console.WriteLine($"Deserialized Person: {deserializedJsonPerson.UserName}, Age: {deserializedJsonPerson.UserAge}");
        Console.WriteLine($"Time taken for JSON deserialization: {stopwatch2.ElapsedMilliseconds} ms");
       }
    }   