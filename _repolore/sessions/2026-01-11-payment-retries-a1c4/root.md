# Session: payment retries

Objective: find why duplicate charges appeared during the provider incident.
Status: active.
Findings: retries reuse the idempotency key (likely, not yet verified).
Next: read `RetryPolicy.cs` and the provider wrapper.
