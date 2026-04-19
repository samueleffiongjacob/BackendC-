# ConsoleDecelization

A simple .NET console app that demonstrates deserialization in three formats:

- Binary (`person.dat`)
- XML (from inline XML string)
- JSON (from inline JSON string)

It also measures and prints the time taken for each deserialization operation.

## Project Goal

This project helps you understand how to deserialize data into a `Person` object using:

- `BinaryReader` for binary data
- `XmlSerializer` for XML
- `System.Text.Json` for JSON

## Prerequisite

The app reads binary data from `person.dat` in the project folder.

If `person.dat` is missing, the app will throw a file not found error.

## Run

From the project directory:

```bash
dotnet run
```

## What the app does

1. Reads `person.dat` and deserializes `UserName` and `UserAge`.
2. Deserializes this XML string:

```xml
<Person><UserName>John Doe</UserName><UserAge>30</UserAge></Person>
```

3. Deserializes this JSON string:

```json
{"UserName":"Jane Doe","UserAge":25}
```

4. Prints deserialized values and elapsed time in milliseconds for each format.

## Main Code Location

- `Program.cs` contains all deserialization logic.
- `Person` model is nested inside `Program`.

## Target Framework

- `.NET 10.0` (`net10.0`)
