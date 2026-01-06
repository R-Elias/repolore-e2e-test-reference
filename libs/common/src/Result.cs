namespace Harbor.Common;

public readonly record struct Result<T>(T? Value, string? Error)
{
    public bool IsSuccess => Error is null;
}
