# SawaggerIntegrationAsp

Minimal ASP.NET Core minimal API example with Swagger integration.

## What this folder contains
- A minimal API with simple in-memory `Blog` data.
- Swagger/OpenAPI configuration via `AddSwaggerGen()` and `UseSwaggerUI()`.
- Endpoints:
  - `GET /` — health/root string
  - `GET /blogs/{id}` — returns a single blog (200) or 404 when not found
  - `POST /blogs` — create a new blog

## Requirements
- .NET SDK 7.0 or later

## Run (development)
From this folder run:

```bash
dotnet watch
# or
dotnet run
```

By default the app prints the listening URL (e.g. `http://localhost:5266`).

## Swagger UI
Open in your browser:

- `http://localhost:<port>/swagger/index.html`
- or simply: `http://localhost:<port>/swagger`

Replace `<port>` with the port shown in the app output (commonly `5266`).

## Example requests
Get blog with id 0:

```bash
curl http://localhost:5266/blogs/0
```

Create a blog:

```bash
curl -X POST http://localhost:5266/blogs \
  -H "Content-Type: application/json" \
  -d '{"name":"My","title":"My Blog","body":"content"}'
```

## Notes / Troubleshooting
- If `dotnet watch` fails trying to open the browser on Linux, install an opener (e.g. `xdg-utils`) or disable auto-launch in `Properties/launchSettings.json` by setting `launchBrowser` to `false`.

```bash
# Debian/Ubuntu
sudo apt update
sudo apt install xdg-utils -y
```

- The project uses `TypedResults`/`Results` to return HTTP results. The code documents multiple responses (200 and 404) so Swagger shows both outcomes.

## Model
The project exposes a simple `Blog` model with these required properties:

- `Name` (string)
- `Title` (string)
- `Body` (string)

## Where to look next
- [Program.cs](Program.cs) — main minimal API and endpoints

---

If you want, I can also add a short `launchSettings.json` snippet or sample Postman collection. Which would you prefer?