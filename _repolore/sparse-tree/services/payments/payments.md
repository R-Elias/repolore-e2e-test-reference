# payments

- Every charge carries an idempotency key ([ADR 0002](../../../adr/0002-idempotent-payments.md)).
- The card provider is wrapped in `src/Payments.Api/Providers/CardProvider.cs`.
