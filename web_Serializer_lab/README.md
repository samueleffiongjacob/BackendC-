# web_Serializer_lab

This project is a simple console app that demonstrates serialization to three formats:

- binary
- XML
- JSON

## What it does

The app creates a sample `Person` object and then:

- writes binary data to `person.dat`
- writes XML data to `person.xml`
- writes JSON data to `person.json`

## Run the project

From the project folder, run:

```bash
dotnet run
```

When it finishes, the generated files will appear in the project folder.

## Sample data

The sample person includes:

- name
- email
- phone
- address
- age

## Notes

- The main logic is in `Program.cs`.
- `person.json` shows the JSON output produced by the app.
- The project is meant to help you understand basic serialization, not to build a full application.
