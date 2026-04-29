using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public class User
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public string GenerateHash()
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(Password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public void EncryptData()
        {
            Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        }
    } 

    public static User? DeserializeUser(string jsonData, bool isTrustedSource)
    {
        if (!isTrustedSource)
        {
            Console.WriteLine("Untrusted source. Deserialization is not allowed.");
            return null;
        }
        return JsonSerializer.Deserialize<User>(jsonData);
    }

    public static string SerializeUser(User user)
    {
       if (
         string.IsNullOrEmpty(user.Name) 
         || string.IsNullOrEmpty(user.Email) 
         || string.IsNullOrEmpty(user.Password)
        )
       {
            Console.WriteLine("Invalid user data. Serialization is not allowed.");
            return string.Empty;
       }
       user.EncryptData();
       return JsonSerializer.Serialize(user);
    }

    public static void Main()
    {
        var user = new User
        {
            Name = "Samuele Effiong",
            Email = "samueleffiong@gmail.com",
            Password = "SecurePassword123"
        };
        string generatedHash = user.GenerateHash();
        string serializedData = SerializeUser(user);
        User? deserializedData = DeserializeUser(serializedData, true);
        Console.WriteLine($"Serialized Data: \n {serializedData} \n Generated Hash: {generatedHash}");
        if (deserializedData is null)
        {
            Console.WriteLine("Deserialization returned null.");
        }
        else
        {
            Console.WriteLine($"Deserialized Data:\n Name={deserializedData.Name},\n Email={deserializedData.Email},\n Password={deserializedData.Password}");
        }
    }
}