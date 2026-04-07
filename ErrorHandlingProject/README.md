# ErrorHandlingProject

This project is an ASP.NET Core Web API, so it is expected to keep running after startup. If the terminal looks like it is "stuck", that is normal behavior: the app is waiting for HTTP requests.

## What it does

This app demonstrates simple error handling for a division endpoint.

- Successful requests return the division result as JSON.
- Dividing by zero returns a friendly `400 Bad Request` response.
- Unhandled exceptions are caught by the global middleware in `Program.cs` and return a `500` response.

## Run the app

Use the normal .NET run command from the project folder:

```bash
dotnet run
```

When the app starts, it will continue running until you stop it manually with `Ctrl+C`.

## API Endpoint

### `GET /api/ErrorHandling/division`

Query parameters:

- `numerator`
- `denominator`

Example:

```bash
curl "http://localhost:5233/api/ErrorHandling/division?numerator=10&denominator=2"
```

Example response:

```json
{
  "result": 5
}
```

If `denominator` is `0`, the API returns:

```text
Denominator cannot be zero. Please provide a valid denominator.
```

## Why the app stays open

The app calls `app.Run()` in `Program.cs`, which starts the web server and keeps the process alive. That means the program is not broken or hung. It is simply waiting for requests.

## Files of interest

- `Program.cs` sets up Serilog, middleware, and controller routing.
- `Controllers/ErrorHandlingController.cs` contains the division endpoint.
