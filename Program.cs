var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/", async (context) =>
{
    await context.Response.WriteAsync("Home");
});

app.Map("/map1", async (context) =>
{
    await context.Response.WriteAsync("In Map 1");
});


app.Run();
