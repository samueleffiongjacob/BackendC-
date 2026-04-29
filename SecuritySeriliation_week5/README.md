# SecuritySeriliation_week5

Small console project demonstrating basic hashing and simple (insecure) serialization/encryption examples.

How to run:

```bash
cd SecuritySeriliation_week5
dotnet run
```

What it does:
- Creates a `User` object, generates a SHA-256 hash of the password, serializes the user to JSON after base64-encoding the password, and deserializes (when allowed).

Notes:
- The project is educational; do not use the simple base64 "encryption" for real secrets.
- See `Program.cs` for implementation details.
