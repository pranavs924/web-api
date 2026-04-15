var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

//Middleware 1
app.Use(async (context, next) => {
    Console.WriteLine("Request Start");
    await next();
    Console.WriteLine("Response End");
});

// Middleware 2
app.Use(async (context , next) =>
{
    Console.WriteLine("Second Middleware");
    await next();
});

app.MapGet("/", () => "Hello from web API Pipeline");

app.Run();