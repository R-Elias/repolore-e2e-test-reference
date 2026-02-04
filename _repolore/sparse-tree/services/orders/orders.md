# orders

- Orders are created `Pending`, become `Reserved` after the inventory reply, then `Paid`.
- Cancelling a `Paid` order requires a refund through payments first.
- Reservations expire after 15 minutes; the expiry job lives in `Orders.Api`.
- SLA: orders confirm in under 5 s (p95), per the January load test.
