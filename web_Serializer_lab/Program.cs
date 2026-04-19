// using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Project
{
    public class Person
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserAge { get; set; }
    }

    static void Main()
    {
        Person samplePerson = new Person 
        {
            UserName = "Samuel Effiong",
            UserEmail = "samuel.effiong@example.com", 
            UserPhone = "123-456-7890", 
            UserAddress = "13 Adeniyi Street, Abuja, Nigeria", 
            UserAge = "30"
        };

        using (FileStream fs = new FileStream("person.dat", FileMode.Create))
        {
           BinaryWriter writer = new BinaryWriter(fs);
           writer.Write(samplePerson.UserName);
           writer.Write(samplePerson.UserEmail);
           writer.Write(samplePerson.UserPhone);
           writer.Write(samplePerson.UserAddress);
           writer.Write(samplePerson.UserAge);  
        }
        Console.WriteLine("Binary serialization completed.");

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
        using (FileStream fs = new FileStream("person.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(fs, samplePerson);
        }
        
        Console.WriteLine("XML serialization completed.");
        string jsonString = JsonSerializer.Serialize(samplePerson);
        File.WriteAllText("person.json", jsonString);
        Console.WriteLine("JSON serialization completed.");
    }
}


