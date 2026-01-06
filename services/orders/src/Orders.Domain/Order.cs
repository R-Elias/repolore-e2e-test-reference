namespace Harbor.Orders.Domain;

public sealed record Order(Guid Id, string CustomerId, IReadOnlyList<OrderLine> Lines, OrderStatus Status);
public sealed record OrderLine(string Sku, int Quantity, decimal UnitPrice);
public enum OrderStatus { Pending, Reserved, Paid, Shipped, Cancelled }
