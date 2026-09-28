# ADR-004: Introduce Redis for the Redirect Path

- Status: Proposed
- Date: 2026-09-22

## Context

Redirect traffic is expected to be much higher than link-creation traffic. The primary database should not necessarily serve every repeated lookup.

## Decision

Introduce Redis after the baseline PostgreSQL implementation has been measured.

The expected strategy is cache-aside:

```text
Read Redis
   |
   +-- hit  -> return destination
   |
   +-- miss -> read PostgreSQL -> populate Redis
```

## Alternatives considered

### Database only

Preferred for the first working version because it establishes a measurable baseline.

### Cache-only architecture

Rejected as the initial source of truth because durability and consistency become unnecessarily complicated.

## Consequences

Positive:

- Lower database read load for hot links.
- Lower latency for cache hits.

Negative:

- Additional infrastructure.
- Cache invalidation becomes a correctness concern.
- Cache availability must be handled as a failure scenario.
