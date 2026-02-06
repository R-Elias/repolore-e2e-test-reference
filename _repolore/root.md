# Harbor

Order-to-delivery platform. Read this before changing anything; then read the note of the area
you touch.

- `services/` holds the three back-end services. Orders orchestrates; payments and inventory are
  called by orders, never by the front ends.
- `web/` holds the storefront and the admin console.
- `libs/` holds shared code. `libs/wide/` and `libs/deep/` are generated and need no notes.
- `infra/` holds Terraform and Kubernetes manifests.
- `vendor/` is third-party code; never edit it in place.

Architecture: [overview](architecture/overview.md). Decisions: [ADR 0001](adr/0001-event-bus.md),
[ADR 0002](adr/0002-idempotent-payments.md).

Release 1.0.0 is in production; `CHANGELOG.md` lists what changed.
