# Architecture

## 1. Architecture principles

1. Start simple.
2. Keep domain behavior independent from infrastructure details.
3. Make reliability properties explicit.
4. Prefer measurable trade-offs over fashionable technologies.
5. Introduce distributed infrastructure only when a concrete requirement demands it.

## 2. Initial architecture

The first release is a modular monolith.

```text
                  +----------------+
Client ---------->| ASP.NET Core   |
                  | API            |
                  +-------+--------+
                          |
                          v
                  +---------------+
                  | PostgreSQL    |
                  +---------------+
```

## 3. Proposed solution structure

```text
src/
  ShortLink.Api/
  ShortLink.Application/
  ShortLink.Domain/
  ShortLink.Infrastructure/

tests/
  ShortLink.UnitTests/
  ShortLink.IntegrationTests/
  ShortLink.LoadTests/
```

### Api

Owns HTTP concerns:

- endpoints/controllers
- middleware
- authentication boundary when introduced
- request/response mapping
- API documentation

### Application

Owns use cases and orchestration:

- create link
- resolve link
- get link details
- disable link
- validation of application rules

### Domain

Owns core business concepts and rules that should not depend on ASP.NET Core or EF Core.

### Infrastructure

Owns external dependencies:

- EF Core
- PostgreSQL
- Redis later
- messaging later
- external services later

## 4. Request flow: create link

```text
POST /api/links
      |
      v
API validation
      |
      v
Application service
      |
      v
Generate code
      |
      v
Repository / EF Core
      |
      v
PostgreSQL
      |
      v
HTTP 201
```

## 5. Request flow: redirect

Initial version:

```text
GET /{code}
      |
      v
Application service
      |
      v
PostgreSQL
      |
      v
HTTP redirect
```

Later version with cache:

```text
GET /{code}
      |
      v
Redis
  |       \
 HIT       MISS
  |          |
  |          v
  |      PostgreSQL
  |          |
  |          v
  +------> Redis
      |
      v
HTTP redirect
```

## 6. Architecture evolution roadmap

### Stage 1: Modular monolith

ASP.NET Core + PostgreSQL.

### Stage 2: Authentication

Add identity and ownership boundaries.

### Stage 3: Caching

Add Redis for the read-heavy redirect path.

### Stage 4: Multi-instance API

Run several stateless API instances behind a load balancer.

### Stage 5: Async analytics

Introduce a queue and worker so analytics do not slow redirects.

### Stage 6: Outbox

Make database changes and message publication reliable.

### Stage 7: Observability and load testing

Use metrics and traces to validate actual bottlenecks.

### Stage 8: Further scaling

Consider read replicas, partitioning, stronger caching strategies or multi-region deployment only if measurements justify them.

## 7. Explicit non-goals for the first release

- Microservices.
- Kubernetes.
- Kafka.
- Event sourcing.
- CQRS everywhere.
- Multi-region deployment.

These may be useful later, but none is required to prove the initial system works.
