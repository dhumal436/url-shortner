# ADR-008: Use an Outbox for Reliable Event Publication

- Status: Proposed
- Date: 2026-09-22

## Context

A future workflow may need to persist a database change and publish an event. Updating the database and sending a message are separate operations and can fail independently.

## Decision

When reliable event publication is required, persist the business change and an outbox record in the same database transaction. A worker publishes pending outbox records and marks them processed.

```text
BEGIN
  business change
  outbox message
COMMIT

worker -> queue
```

## Consequences

Positive:

- Reduces the chance of losing events between a database commit and message publication.

Negative:

- Adds storage and worker complexity.
- Delivery is still generally at-least-once, so consumers need idempotency.
