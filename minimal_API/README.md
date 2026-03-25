# Minimal API (ASP.NET Core)

A simple ASP.NET Core Minimal API example with basic HTTP endpoints.

## Requirements

- .NET SDK 10.0 (preview)

## Run the Project

From the `minimal_API` folder:

```bash
dotnet run
```

By default, ASP.NET Core prints the local URLs in the terminal (for example `http://localhost:5000` and/or `https://localhost:5001`). Use one of those as your base URL.

## Endpoints

| Method | Route | Description | Example Response |
|---|---|---|---|
| GET | `/` | Basic hello endpoint | `Hello World!` |
| GET | `/download` | Download example message | `This is a file download example.` |
| GET | `/time` | Returns server local time | `14:35:12` |
| GET | `/greet/{name}` | Greets by path parameter | `Hello, Sam!` |
| POST | `/` | Sample POST endpoint | `{ "message": "This is a post endpoint." }` |
| PUT | `/` | Sample PUT endpoint | `{ "message": "Welcome to the minimal API!" }` |
| DELETE | `/delete` | Sample DELETE endpoint | `This is a delete endpoint.` |

## Quick Test Examples

Replace `<BASE_URL>` with your running URL.

```bash
curl <BASE_URL>/
curl <BASE_URL>/download
curl <BASE_URL>/time
curl <BASE_URL>/greet/Sam
curl -X POST <BASE_URL>/
curl -X PUT <BASE_URL>/
curl -X DELETE <BASE_URL>/delete
```

## Project Structure

- `Program.cs`: Contains all endpoint mappings.
- `appsettings.json` and `appsettings.Development.json`: Configuration files.
- `requests.http`: Optional local request file for manual testing in VS Code.
