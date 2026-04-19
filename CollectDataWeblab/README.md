# CollectDataWeblab

This project is a clean serialization lab built with ASP.NET Core.
It lets you create users first (no hard-coded users), then export them in different formats.

## Goals

- Create users through an API request body.
- Keep business logic in a controller and service.
- Keep serialization logic in middleware.
- Keep export endpoints in a route class.
- Use dependency injection and Swagger for clean structure and testing.

## Project Structure

- `Model/User.cs`
  - User model used for input and output.
- `Controllers/UserController.cs`
  - Business logic for creating and listing users.
- `Middleware/Usermiddleware.cs`
  - Serialization logic for `json`, `xml`, `dat`, and `binary`.
- `Routing/UserRoute.cs`
  - Export endpoints.
- `Services/IUserService.cs`, `Services/InMemoryUserService.cs`
  - DI-based in-memory data store.
- `Program.cs`
  - DI registration, middleware pipeline, routing, and Swagger.

## Run the App

```bash
dotnet restore
dotnet run
```

Open Swagger UI (in Development):

- `https://localhost:<port>/swagger`
- or `http://localhost:<port>/swagger`

## Quick API Testing (requests.http)

Use `requests.http` in this folder with the VS Code REST Client extension.

Included requests:

- Health check (`GET /`)
- Create user (`POST /api/user`)
- List users (`GET /api/user`)
- Export users as JSON (`GET /api/users/export/json`)
- Export users as XML (`GET /api/users/export/xml`)
- Export users as DAT (`GET /api/users/export/dat`)
- Export users as binary (`GET /api/users/export/binary`)

If your local port is different, update `@CollectDataWeblab_HostAddress` at the top of `requests.http`.

## API Endpoints

### 1) Create User

`POST /api/user`

Example body:

```json
{
  "name": "Ada Lovelace",
  "email": "ada@example.com",
  "age": 28
}
```

### 2) List Users

`GET /api/user`

### 3) Export Users (Routing layer)

- `GET /api/users/export/json`
- `GET /api/users/export/xml`
- `GET /api/users/export/dat`
- `GET /api/users/export/binary`

These endpoints use middleware to serialize data and return downloadable content.

## Important Notes

- Add users first with `POST /api/user`, then export.
- Data is stored in memory (`InMemoryUserService`), so it resets when the app restarts.
- `dat` and `binary` are returned as `application/octet-stream`.

## Dependency Injection

DI is used for the user service:

- `IUserService` is registered as `InMemoryUserService` in `Program.cs`.
- Controller and route handlers consume the service through constructor/parameter injection.
