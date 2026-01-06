var app = WebApplication.Create(args);
app.MapPost("/payments", (PaymentRequest request, PaymentGateway gateway) => gateway.Charge(request));
app.Run();
