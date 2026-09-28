# ADR-006: Enforce Code Uniqueness at the Database Boundary

- Status: Accepted
- Date: 2026-09-22

## Context

Concurrent requests can generate or request the same short code.

## Decision

Create a unique database constraint on the short-code column and handle duplicate-key failures in application code.

## Rationale

An application-level check such as "query first, then insert" is not sufficient under concurrency because multiple requests can observe the same state before either inserts.

## Consequences

- The database remains the final authority for uniqueness.
- Application code must translate duplicate-key failures into safe behavior.
