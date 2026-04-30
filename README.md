# Backend C# Learning Roadmap

This repository is a collection of small ASP.NET Core and C# practice projects. I built it as a step-by-step learning path, starting from basic console concepts and moving toward web APIs, middleware, dependency injection, error handling, serialization, security, and more advanced backend patterns.

## How To Use This Repository

1. Start from the beginner section and move down in order.
2. Open one folder at a time and read its local `README.md`.
3. Run each project separately with `dotnet run` from that project folder.
4. Test endpoints with the `.http` files when they are available.
5. Repeat projects after you understand them so you can compare the patterns.

## Learning Path

### 1. Beginner Level: C# Basics And Data Conversion

This stage focuses on understanding objects, file handling, and how data moves between formats.

- [ConsoleDecelization](ConsoleDecelization/) - console app for deserialization from binary, XML, and JSON.
- [Serializing_and_Deserializing_JSON](Serializing_and_Deserializing_JSON/) - JSON serialization and deserialization practice.
- [Web_Serialization](Web_Serialization/) - returning data as JSON and XML from a web API.
- [web_Serializer_lab](web_Serializer_lab/) - extra lab work around serialization.

### 2. Building Your First APIs

This stage introduces ASP.NET Core Minimal APIs and basic request handling.

- [minimal_API](minimal_API/) - simple HTTP verbs, route parameters, and response examples.
- [crud_minimal_API](crud_minimal_API/) - CRUD-style minimal API practice.
- [Routing](Routing/) - route matching and endpoint organization.
- [LabTestApi](LabTestApi/) - API practice lab.

### 3. Working With Dependencies And Services

Here the focus moves from simple endpoints to application structure and service lifetimes.

- [Dependency_Injection](Dependency_Injection/) - singleton, scoped, and transient lifetimes.
- [Test_Dependency_Injection](Test_Dependency_Injection/) - testing and verifying DI behavior.

### 4. Middleware And Request Pipeline

This stage explains how ASP.NET Core processes requests before they reach endpoints.

- [Middleeware](Middleeware/) - custom middleware order and logging.
- [Design_api_medilleware_week5](Design_api_medilleware_week5/) - middleware design and request flow notes.
- [MIDDLEWARE_OPTIMIAZATION_WEEK6/SecuredMiddleware](MIDDLEWARE_OPTIMIAZATION_WEEK6/SecuredMiddleware/) - more advanced middleware and security-related pipeline work.

### 5. Error Handling, Logging, And Stability

This stage shows how to make APIs safer and easier to debug.

- [ErrorHandlingProject](ErrorHandlingProject/) - friendly validation, global exception handling, and Serilog logging.

### 6. Security And Serialization Topics

This stage combines API behavior with safer data handling and security-related practice.

- [SecuritySeriliation_week5](SecuritySeriliation_week5/) - security and serialization-related exercises.
- [Decerilaze](Decerilaze/) - deserialization practice and related data flow.

### 7. Data Collection And Web Lab Work

This stage contains more applied backend exercises and lab-style projects.

- [CollectDataWeblab](CollectDataWeblab/) - collecting and processing data in a web application.
- [AI_webapi](AI_webapi/) - web API experimentation in a more advanced project structure.
- [Design_api_medilleware_week5/SawaggerIntegrationAsp](Design_api_medilleware_week5/SawaggerIntegrationAsp/) - Swagger and API documentation integration practice.
- [Design_api_medilleware_week5/sawagaerfrontend](Design_api_medilleware_week5/sawagaerfrontend/) - frontend integration notes and experiments.
- [Design_api_medilleware_week5/sawagaerfrontend1](Design_api_medilleware_week5/sawagaerfrontend1/) - another frontend or integration variant.

## Suggested Beginner To Advanced Order

If you want the cleanest learning sequence, follow this order:

1. `ConsoleDecelization`
2. `Serializing_and_Deserializing_JSON`
3. `Web_Serialization`
4. `minimal_API`
5. `Routing`
6. `crud_minimal_API`
7. `Dependency_Injection`
8. `Test_Dependency_Injection`
9. `Middleeware`
10. `ErrorHandlingProject`
11. `SecuritySeriliation_week5`
12. `CollectDataWeblab`
13. `AI_webapi`
14. `Design_api_medilleware_week5`
15. `MIDDLEWARE_OPTIMIAZATION_WEEK6/SecuredMiddleware`

## What I Learned In This Repository

- How to build and run .NET projects.
- How to deserialize and serialize data in multiple formats.
- How to create Minimal APIs with GET, POST, PUT, and DELETE routes.
- How route parameters and request bodies work.
- How to register and compare service lifetimes in Dependency Injection.
- How middleware wraps request execution.
- How to handle errors cleanly and return useful responses.
- How to add logging and observe application behavior.
- How to organize backend practice into small, focused modules.

## Common Run Pattern

From inside any project folder:

```bash
dotnet run
```

If the project includes a `.http` file, you can use it with the REST Client extension in VS Code to send requests quickly.

## Notes

- Each folder is a separate practice module.
- Most of the code is intentionally small so the concept is easy to understand.
- The repository works best if you study one topic, run it, then move to the next.
