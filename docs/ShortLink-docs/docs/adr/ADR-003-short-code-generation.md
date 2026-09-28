# ADR-003: Short-Code Generation Strategy

- Status: Proposed
- Date: 2026-09-22

## Context

Every shortened URL needs a compact unique code.

## Options to evaluate

1. Random Base62 code.
2. Database-generated numeric identifier encoded as Base62.
3. Distributed identifier encoded as Base62.

## Decision

To be finalized after evaluating:

- collision behavior
- predictability
- storage size
- distributed generation requirements
- operational simplicity

## Consequence

The implementation should keep code generation behind an abstraction so the strategy can be changed without rewriting link persistence or HTTP behavior.
