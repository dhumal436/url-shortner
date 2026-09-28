# ShortLink

Production-grade URL shortener built as a learning project for modern .NET and system design.

## Goal

Use a deliberately simple URL shortener to learn how a real production system evolves:

1. ASP.NET Core API
2. PostgreSQL + EF Core
3. Authentication and authorization
4. Redis caching
5. Concurrency and consistency
6. Rate limiting
7. Background processing and messaging
8. Outbox pattern
9. Observability
10. Load testing
11. Horizontal scaling

## Documentation

See the [`docs/`](./docs) directory.

| Document | Purpose |
|---|---|
| [Requirements](./docs/requirements.md) | Functional and non-functional requirements |
| [Architecture](./docs/architecture.md) | System architecture and evolution |
| [API](./docs/api.md) | HTTP API contract |
| [Database](./docs/database.md) | Data model, constraints, indexes and transactions |
| [Scaling](./docs/scaling.md) | Capacity assumptions and scaling strategy |
| [ADR index](./docs/adr/README.md) | Architecture decisions and trade-offs |

## Current architectural target

Start as a modular monolith. Add infrastructure only when a documented problem justifies it.

```text
Client
  |
  v
ASP.NET Core API
  |
  v
PostgreSQL
```

Later, the system can evolve toward Redis, background workers, messaging and horizontal scaling.
