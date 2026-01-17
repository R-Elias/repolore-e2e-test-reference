# orders

- Orders are created `Pending`, become `Reserved` after the inventory reply, then `Paid`.
- Cancelling a `Paid` order requires a refund through payments first.
- Reservations expire after 15 minutes; the expiry job lives in `Orders.Api`.
- Outages: see the [orders runbook](../../../../docs/runbooks/orders-outage.md) and the
  [shared notes](../../../../../shared-notes.md).
