# ADR-005: Process Analytics Asynchronously

- Status: Proposed
- Date: 2026-09-22

## Context

Recording click analytics directly in the redirect request would couple user-visible redirect latency to analytics persistence.

## Decision

The eventual design should emit an analytics event and process it asynchronously using a worker.

```text
Redirect request
    |
    +----> redirect response
    |
    +----> analytics event -> queue -> worker -> analytics storage
```

## Consequences

- Redirect latency is less dependent on analytics storage.
- Analytics become eventually consistent.
- Message delivery, retries and duplicates must be handled.
