using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;


//  generate frontend client code from swagger json file using NSwag code generation tools
public class ClientGenerator
{
    public static async Task Main()
    {
        var HttpClient = new HttpClient();
        var apiUrl = "http://localhost:5266/swagger/v1/swagger.json";
        var SawaggerJson = await HttpClient.GetStringAsync(apiUrl);
        var document = await OpenApiDocument.FromJsonAsync(SawaggerJson);
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "ApiClient",
            CSharpGeneratorSettings =
            {
                Namespace = "SawaggerIntegrationAsp"
            }
        };
        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();
        var outputPath = "ApiClient.cs";
        await File.WriteAllTextAsync(outputPath, code);
    }
}