# Decerilaze

This project demonstrates different ways to deserialize JSON and XML into C# objects.

## What it shows

The app receives JSON or XML data from a client and deserializes it into a `Person` object.
Different endpoints demonstrate various deserialization techniques:

- Automatic deserialization by ASP.NET Core
- Manual JSON deserialization with `ReadFromJsonAsync`
- Custom deserialization options (strict validation, case-insensitive, comments, etc.)
- XML deserialization using `XmlSerializer`

## Run the project

From the project folder, run:

```bash
dotnet run
```

## API Endpoints

### 1) Health check

`GET /`

Simple text response to verify the app is running.

### 2) Auto Deserialization

`POST /auto`

ASP.NET Core automatically deserializes JSON to `Person`.

Example request:

```json
{
  "userName": "Ada Lovelace",
  "userAge": 28
}
```

### 3) Manual JSON Deserialization

`POST /json`

Manual deserialization using `ReadFromJsonAsync<Person>`.

Example request:

```json
{
  "userName": "Alan Turing",
  "userAge": 35
}
```

### 4) Custom JSON Deserialization with Options

`POST /custom-options`

Deserialization with custom `JsonSerializerOptions`:
- `UnmappedMemberHandling.Disallow` - rejects unknown fields
- `PropertyNameCaseInsensitive` - ignores case in property names
- `AllowTrailingCommas` - allows trailing commas in JSON
- `ReadCommentHandling.Skip` - allows comments in JSON

Includes error handling for invalid input.

### 5) XML Deserialization

`POST /xml`

Deserializes XML data using `XmlSerializer`.

Example request:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Person>
  <UserName>Linus Torvalds</UserName>
  <UserAge>54</UserAge>
</Person>
```

## Quick Testing

Use `requests.http` with the VS Code REST Client extension.

All endpoints are included with sample data ready to send.

## Model

The `Person` class used for deserialization:

```csharp
public class Person
{
    required public string UserName { get; set; }
    public int? UserAge { get; set; }
}
```

## Notes

- JSON property names are converted to camelCase in requests.
- XML requires proper XML structure with matching element names.
- The custom options endpoint will reject requests with unknown JSON fields.
- Error responses include details about what went wrong.
