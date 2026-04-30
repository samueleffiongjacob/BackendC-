# sawagaerfrontend

This project is an ASP.NET Core Web API with Swagger enabled and an NSwag-based client generator.

## Prerequisites

- .NET SDK 10.0+

## Run the API

From this folder:

```bash
dotnet run
```

Swagger UI:

- http://localhost:5203/swagger

Swagger JSON:

- http://localhost:5203/swagger/v1/swagger.json

## Generate C# API Client

Run:

```bash
dotnet run -- --generate-client
```

What this does:

- Starts the API
- Reads Swagger JSON from `/swagger/v1/swagger.json`
- Generates `ApiClient.cs` in this same folder
- Stops the API

## Files

- `Program.cs`: API startup and `--generate-client` flow
- `ClientGenarator.cs`: NSwag code generation logic
- `ApiClient.cs`: generated client file