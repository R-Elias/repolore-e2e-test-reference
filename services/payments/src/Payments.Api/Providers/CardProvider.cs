namespace Harbor.Payments.Providers;

public sealed class CardProvider
{
    public Task<ChargeResult> Charge(string idempotencyKey, decimal amount) => throw new NotImplementedException();
}
