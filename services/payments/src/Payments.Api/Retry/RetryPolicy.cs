namespace Harbor.Payments.Retry;

public static class RetryPolicy
{
    public const int MaxAttempts = 3;
    public static TimeSpan Delay(int attempt) => TimeSpan.FromMilliseconds(200 * Math.Pow(2, attempt) + Random.Shared.Next(0, 100));
}
