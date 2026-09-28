# Architecture Decision Records

Architecture Decision Records capture important decisions, alternatives and trade-offs.

## Index

| ADR | Decision |
|---|---|
| [ADR-001](./ADR-001-modular-monolith.md) | Start with a modular monolith |
| [ADR-002](./ADR-002-postgresql.md) | Use PostgreSQL as the primary database |
| [ADR-003](./ADR-003-short-code-generation.md) | Choose and document a short-code generation strategy |
| [ADR-004](./ADR-004-redis.md) | Introduce Redis for the read-heavy redirect path when justified |
| [ADR-005](./ADR-005-analytics-async.md) | Process analytics asynchronously |
| [ADR-006](./ADR-006-unique-code-concurrency.md) | Enforce code uniqueness at the database boundary |
| [ADR-007](./ADR-007-rate-limiting.md) | Define rate-limiting boundaries |
| [ADR-008](./ADR-008-outbox.md) | Use an outbox for reliable event publication |
