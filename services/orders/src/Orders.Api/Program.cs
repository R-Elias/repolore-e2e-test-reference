var app = WebApplication.Create(args);
app.MapPost("/orders", (CreateOrder command, OrderHandler handler) => handler.Handle(command));
app.Run();
