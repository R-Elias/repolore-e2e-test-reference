# Architecture overview

Storefront → orders → (inventory, payments). Orders publishes `OrderPaid` on the event bus; the
admin console only reads.

See the [orders](../sparse-tree/services/orders/orders.md) and
[payments](../sparse-tree/services/payments/payments.md) notes.
