using HarshaASP.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello-1 Starts\n");
    await next(context);
    await context.Response.WriteAsync("Hello-1 Finish\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello-2 Starts\n");
    await next(context);
    await context.Response.WriteAsync("Hello-2 Finish\n");
});

//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello-3\n");
});

app.Run();
