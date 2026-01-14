# payments

- Every charge carries an idempotency key ([ADR 0002](../../../adr/0002-idempotent-payments.md)).
- The card provider is wrapped in `src/Payments.Api/Providers/CardProvider.cs`.
- Retries (3 attempts, exponential backoff with jitter) reuse the same idempotency key, so a retried
  charge is never billed twice. Verified in `RetryPolicy.cs` and `CardProvider.cs`.
