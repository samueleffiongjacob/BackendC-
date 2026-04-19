# Web_Serialization

This project is a small ASP.NET Core web API that demonstrates different ways to return data as JSON and XML.

## What it shows

The app creates one sample `Person` object and returns it in several formats:

- normal JSON from the API
- manual JSON serialization
- custom JSON serialization settings
- automatic JSON response from ASP.NET Core
- XML response using `XmlSerializer`

## Run the project

From the project folder, run:

```bash
dotnet run
```

Then call the endpoints from the `.http` file or from a browser.

## Endpoints

- `GET /` - simple text response
- `GET /person` - returns the sample person as JSON
- `GET /manual-json` - returns manually serialized JSON
- `GET /custom-serializer` - returns JSON with custom serializer settings
- `GET /me` - returns JSON using `TypedResults.Json`
- `GET /auto` - returns the object directly and lets ASP.NET Core serialize it
- `GET /xml` - returns the sample person as XML

## Notes

- `Program.cs` contains all the endpoint examples.
- `Person` is defined at the bottom of `Program.cs`.
- The `.http` file can be used to test the endpoints quickly.
