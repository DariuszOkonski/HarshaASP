var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello-1\n");
    await next(context);
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello-2\n");
    await next(context);
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello-3\n");
});

app.Run();
