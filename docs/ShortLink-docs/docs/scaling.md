# Scaling and Capacity

## 1. Initial assumptions

The project starts with these working assumptions:

```text
Stored links:        10 million
Create traffic:      100 requests/sec target
Redirect traffic:    1,000 requests/sec target
Availability:        99.9%
Redirect p95:        < 100 ms target
```

These values are for engineering exercises. They must be validated or revised using measurements.

## 2. Read/write characteristics

URL shorteners are normally read-heavy.

Conceptually:

```text
Writes
  |
  |  small volume
  v
PostgreSQL

Reads
  |
  |  high volume
  v
Redirect path
```

This makes the redirect path the natural focus for caching and horizontal scaling.

## 3. Scaling stages

### Stage 1

Single application instance + PostgreSQL.

### Stage 2

Add Redis for frequently accessed links.

```text
API -> Redis -> PostgreSQL on miss
```

### Stage 3

Run multiple stateless API instances.

```text
Load Balancer
  |
  +-- API-1
  +-- API-2
  +-- API-3
```

### Stage 4

Move analytics processing off the synchronous redirect path.

```text
API -> Queue -> Worker -> Analytics store
```

### Stage 5

Investigate database scaling options:

- read replicas
- connection-pool tuning
- partitioning where justified
- archival/retention policies

### Stage 6

Only when necessary, investigate multi-region architecture.

## 4. Bottlenecks to measure

- API CPU
- API memory
- PostgreSQL CPU
- PostgreSQL query latency
- connection-pool saturation
- Redis latency
- Redis hit ratio
- network latency
- queue depth
- worker throughput

## 5. Failure scenarios

The system should be deliberately tested for:

### PostgreSQL unavailable

Create and detail operations should fail predictably. Redirect behavior depends on cache availability and cache policy.

### Redis unavailable

The API should degrade to PostgreSQL where possible rather than treating cache failure as application failure.

### Queue unavailable

Synchronous redirect behavior should not depend on analytics message delivery. Reliable event handling is a later concern.

### One API instance unavailable

A load-balanced multi-instance deployment should continue serving requests.

## 6. Load-testing questions

Before and after each scaling change, measure:

```text
RPS
p50
p95
p99
error rate
CPU
memory
DB connections
DB latency
cache hit ratio
```

The goal is not to chase a large RPS number. The goal is to understand what changed and why.
