# API Design

Base path:

```text
/api
```

Redirect endpoint intentionally lives outside `/api` so short URLs remain compact.

## 1. Create link

```http
POST /api/links
Content-Type: application/json
```

Request:

```json
{
  "url": "https://example.com/products/item-123",
  "expiresAt": null
}
```

Response:

```http
201 Created
Content-Type: application/json
```

```json
{
  "id": "...",
  "code": "aB72xK",
  "shortUrl": "https://short.example/aB72xK",
  "originalUrl": "https://example.com/products/item-123",
  "createdAt": "2026-09-22T10:00:00Z",
  "expiresAt": null,
  "isActive": true
}
```

## 2. Redirect

```http
GET /{code}
```

Expected success:

```http
302 Found
Location: https://example.com/products/item-123
```

The exact redirect status may be changed later based on caching semantics and product requirements.

## 3. Get link details

```http
GET /api/links/{id}
```

Example response:

```json
{
  "id": "...",
  "code": "aB72xK",
  "shortUrl": "https://short.example/aB72xK",
  "originalUrl": "https://example.com/products/item-123",
  "createdAt": "2026-09-22T10:00:00Z",
  "expiresAt": null,
  "isActive": true
}
```

## 4. Disable link

```http
DELETE /api/links/{id}
```

Initial semantics: disable the link rather than necessarily deleting historical data.

## 5. Error format

Use a consistent problem-details response.

Example:

```json
{
  "type": "https://example.com/problems/validation-error",
  "title": "Validation failed",
  "status": 400,
  "detail": "The supplied URL is invalid."
}
```

## 6. API rules

- Validate URLs before persistence.
- Never trust client-provided IDs or ownership information.
- Keep redirect responses fast.
- Do not expose internal exception details.
- Add idempotency behavior only when a use case actually requires it.

## 7. Future endpoints

Potential additions:

```text
POST   /api/auth/register
POST   /api/auth/login
POST   /api/auth/refresh
GET    /api/me/links
GET    /api/links/{id}/analytics
POST   /api/links/{id}/rotate-code
```

These are deliberately excluded from the initial implementation.
