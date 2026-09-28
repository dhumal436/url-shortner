# ADR-007: Rate-Limiting Boundaries

- Status: Proposed
- Date: 2026-09-22

## Context

A public URL-shortening service can be abused by automated clients and may need protection for both resource usage and abuse prevention.

## Decision

Evaluate rate limiting separately for:

- authentication endpoints
- link creation
- redirect traffic

The first implementation should use ASP.NET Core's rate-limiting capabilities, then revisit edge-level controls after load testing.

## Consequences

- Traffic protection becomes explicit.
- Limits must be tuned using observed workload rather than arbitrary numbers.
- Distributed deployments require careful consideration of shared rate-limit state.
