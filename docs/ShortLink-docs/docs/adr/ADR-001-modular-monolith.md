# ADR-001: Start with a Modular Monolith

- Status: Accepted
- Date: 2026-09-22

## Context

The project is intended to teach .NET and system design. Starting with distributed services would introduce operational complexity before there is a demonstrated need for it.

## Decision

Start with a modular monolith containing Api, Application, Domain and Infrastructure boundaries.

## Alternatives considered

### Microservices from day one

Rejected for the initial stage because service boundaries and operational costs are not yet justified.

### Single project with no boundaries

Rejected because it makes later architectural evolution and dependency control harder.

## Consequences

Positive:

- Easier local development.
- Easier debugging.
- Fewer operational dependencies.
- Clear learning path.

Negative:

- Some future decomposition work may be required.
- Module boundaries must be maintained deliberately.
