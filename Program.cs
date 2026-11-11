var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/map1", async (context) =>
{
    await context.Response.WriteAsync("In Map 1");
});

app.Map("/map2", async (context) =>
{
    await context.Response.WriteAsync("In Map 2");
});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});


app.Run();
