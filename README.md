# MinimalWebHook

A minimal, event-driven backend built with **.NET 9**, designed to receive WiFi credentials via a webhook and persist them safely using **Clean Architecture** principles.

This project focuses on **intentional backend design**, not on toy CRUD examples or framework-specific demos.

---

## Overview

MinimalWebHook exposes a single HTTPS webhook endpoint that ingests data asynchronously from an external source and processes it through a cleanly separated architecture:

- API layer for request handling
- Application layer for use case orchestration
- Domain layer for core models and rules
- Infrastructure layer for persistence and integration

The system is deliberately simple, explicit, and defensive by design.

---

## Architecture

The solution follows **Clean Architecture**, with strict separation of responsibilities:

- **API**  
  Receives HTTP requests, validates input, and delegates processing.  
  Contains no business logic.

- **Application**  
  Defines and orchestrates use cases through interfaces.  
  Coordinates domain logic and persistence.

- **Domain**  
  Contains the core model and domain rules.  
  Free of frameworks, infrastructure, and transport concerns.

- **Infrastructure**  
  Implements persistence (SQLite), credential extraction, logging, and external integrations.  
  All technical details live here.

This structure keeps the core of the system stable even as infrastructure or transport mechanisms change.

---

## Development Environment

The project was developed and tested using:

- **Linux Mint 21.3**
- **.NET SDK 9.0.203**
- **Visual Studio Code 1.107.1**
- **C# Dev Kit extension**

All screenshots and examples were produced in a Linux environment.

That said, the codebase is fully **cross-platform** and works the same way on Windows and macOS.  
It can also be opened directly in Visual Studio if preferred.

---

## Webhook Design

- The API exposes **a single POST endpoint**
- The endpoint is used only for data ingestion
- There are **no endpoints** to list, update, or delete records
- The webhook acts as a thin boundary:
  - validates input
  - delegates processing
  - stays free of business logic

This is not a REST API intended for browsing — it is an ingestion point for events.

---

## Security

- HTTPS is mandatory
- Certificates are managed externally (e.g. via certbot)
- Kestrel is configured to bind only to secure endpoints
- The application fails fast if certificates are missing or invalid

Security is enforced at the boundary and kept out of business logic.

---

## Persistence

- Data is stored using **SQLite**
- Access is encapsulated behind repository abstractions
- The database schema follows the domain model, not the other way around

Persistence is an implementation detail, not a design driver.

---

## Scope and Disclaimer

This project is intended for **educational and research purposes**.

The backend starts at the point where data already exists.  
How credentials are obtained or extracted is outside the scope of this repository.

The focus here is on:
- backend design
- architectural boundaries
- event-driven ingestion
- safe persistence

---

## License

This project is released into the **public domain** under **The Unlicense**.

You are free to:
- use it
- modify it
- redistribute it
- embed it
- break it
- rebuild it

No attribution required.

See the `LICENSE` file for details.

---

## Related Article

This project is explained in detail in the accompanying article:

**A Cyberpunk Take on CRUD: Building a WiFi Credential Webhook with .NET 9, Kestrel, and SQLite**

(Full architectural walkthrough, design decisions, and security considerations.)

---

## Final Note

This repository exists to demonstrate that backend systems can be:
- minimal without being naive
- structured without being heavy
- secure without being complex

Boring code. Clear boundaries. Real behavior.
