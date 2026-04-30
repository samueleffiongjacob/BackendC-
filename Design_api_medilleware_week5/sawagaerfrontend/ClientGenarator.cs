using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;


// Corrected: this is a helper method for generating the client, not a second app entry point.
public class ClientGenerator
{
    public static async Task GenerateClientAsync(string swaggerUrl, string outputPath)
    {
        using var httpClient = new HttpClient();
        var swaggerJson = await httpClient.GetStringAsync(swaggerUrl);
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "ApiClient",
            CSharpGeneratorSettings =
            {
                Namespace = "sawagaerfrontend"
            }
        };
        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();
        await File.WriteAllTextAsync(outputPath, code);
    }
}