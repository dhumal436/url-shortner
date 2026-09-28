# Requirements

## 1. Project objective

ShortLink is a production-oriented URL shortening service used to learn modern .NET engineering and system design.

The initial implementation should be small enough to understand end-to-end, while the requirements should leave room for controlled evolution.

## 2. Scope

### In scope for the initial release

- Create a shortened URL from a valid destination URL.
- Redirect a short code to its destination URL.
- Retrieve information about a short link.
- Delete or disable a short link.
- Generate unique short codes.
- Store creation and optional expiration timestamps.
- Persist data in PostgreSQL.
- Validate requests and return consistent API errors.
- Provide automated unit and integration tests.
- Provide structured logging.

### Deferred

- User accounts and authentication.
- Custom aliases.
- Analytics.
- Redis caching.
- Rate limiting.
- Background workers.
- Message queues.
- Custom domains.
- QR code generation.
- Advanced abuse protection.

These will be introduced in later stages so architectural decisions can be justified by an actual problem.

## 3. Functional requirements

### FR-01 Create link

The system shall accept a destination URL and return a unique short code.

### FR-02 Redirect

A request to `/{code}` shall redirect to the stored destination URL when the link exists, is active and has not expired.

### FR-03 Not found

An unknown short code shall return an appropriate HTTP response.

### FR-04 Expiration

A link may have an expiration timestamp. Expired links shall not redirect.

### FR-05 Disable

A link may be disabled without physically deleting its record.

### FR-06 Link details

The API shall expose link metadata for a known link identifier.

### FR-07 Uniqueness

Short codes shall be unique at the database level, not only by application logic.

## 4. Non-functional requirements

Initial engineering targets, subject to revision after measurement:

| Attribute | Target |
|---|---|
| Availability | 99.9% for the application service |
| Redirect latency | p95 under 100 ms in a warm local/production-like environment |
| Initial URL volume | 10 million links |
| Initial redirect traffic | 1,000 requests/sec target for load testing |
| Data durability | No accepted link creation should be silently lost |
| Security | Validate and constrain all external input |
| Observability | Logs, health checks and basic metrics |
| Deployability | Repeatable Docker-based deployment |

Targets are engineering assumptions, not measured guarantees.

## 5. Constraints

- The first version should remain understandable by one developer.
- Prefer PostgreSQL database constraints over application-only assumptions.
- Avoid premature distributed infrastructure.
- Record significant architectural decisions in ADRs.
- Measure before optimizing.

## 6. Success criteria

The initial release is successful when:

- The service can create and resolve links reliably.
- Duplicate short codes cannot be persisted.
- Expired and disabled links are handled correctly.
- Unit and integration tests cover critical behavior.
- The service can be run locally with documented steps.
- The architecture can be extended without rewriting the entire application.
