var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () =>
{
    Console.WriteLine($"Health check at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    return Results.Ok(new { status = "healthy", timestamp = DateTime.Now });
});

app.MapPost("/webhook", async (HttpContext context) =>
{
    using StreamReader reader = new(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Console.WriteLine($"Body Length: {body.Length} characters");
    Console.WriteLine("Body Content:");
    Console.WriteLine(body);

    return Results.Ok(new { 
        message = "ack",
        timestamp = DateTime.Now,
        bodyLength = body.Length
    });
});

app.Run();
