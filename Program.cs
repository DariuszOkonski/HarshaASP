var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.MapGet("/home", () => "My Home");

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["MyKey"] = "My value";
    context.Response.Headers["Server"] = "My server";
    context.Response.Headers["Content-Type"] = "text/html";

    string path = context.Request.Path;


    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>World</h2>");
    await context.Response.WriteAsync($"<p>{path}</p>");


});

app.Run();
