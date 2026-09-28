# ADR-002: Use PostgreSQL as the Primary Database

- Status: Accepted
- Date: 2026-09-22

## Context

The initial system needs durable storage for links, constraints, indexing and transactional behavior.

## Decision

Use PostgreSQL as the system of record.

## Alternatives considered

### NoSQL document database

Possible, but not necessary for the initial data model. The project benefits from relational constraints and transactions.

### In-memory storage

Suitable only for experiments, not for the production-grade project target.

## Consequences

- Strong relational constraints are available.
- SQL query planning and indexing become part of the learning scope.
- A relational schema must be managed through migrations.
