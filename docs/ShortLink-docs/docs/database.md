# Database Design

## 1. Database

PostgreSQL is the planned relational database for the project.

The database is the source of truth for link persistence in the initial architecture.

## 2. Initial schema

### Links

| Column | Type | Notes |
|---|---|---|
| Id | UUID or bigint | Primary key; choice to be finalized |
| Code | varchar | Short URL code |
| OriginalUrl | text | Destination URL |
| CreatedAt | timestamptz | Creation time in UTC |
| ExpiresAt | timestamptz nullable | Optional expiration |
| IsActive | boolean | Soft-disable flag |
| CreatedBy | nullable initially | Future owner reference |

## 3. Constraints

At minimum:

```text
PRIMARY KEY (Id)
UNIQUE (Code)
NOT NULL (OriginalUrl)
```

Application checks are useful for friendly validation, but the database constraint is the final protection against races.

## 4. Indexes

Initial expected indexes:

```text
PK(Id)
UNIQUE(Code)
INDEX(ExpiresAt)
```

Additional indexes should be added only for demonstrated query patterns.

## 5. Future tables

### Users

```text
Id
Email
PasswordHash
CreatedAt
```

### LinkClicks

```text
Id
LinkId
Timestamp
IpAddress
UserAgent
Referrer
Country
```

### OutboxMessages

```text
Id
OccurredAt
Type
Payload
ProcessedAt
Attempts
```

## 6. Transactions

For initial link creation, the database transaction boundary should match the persistence operation unless a later use case requires more work.

For future outbox publishing:

```text
BEGIN
  Insert Link
  Insert OutboxMessage
COMMIT
```

A worker can then publish unprocessed outbox messages.

## 7. Concurrency

Custom aliases and generated-code collisions must be safe under concurrent requests.

Do not rely on:

```text
check if code exists
then insert
```

alone. Two concurrent requests can both observe that a value does not exist.

Use a database unique constraint and handle duplicate-key failures safely.

## 8. Performance investigation

For any suspected slow query:

```sql
EXPLAIN ANALYZE
```

Measure before adding indexes or changing schema.

## 9. Data lifecycle

Future decisions to document:

- retention period for analytics
- deletion versus soft deletion
- expiration cleanup strategy
- backup and restore policy
- schema migration policy
