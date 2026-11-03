var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.MapGet("/home", () => "My Home");

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";


    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string authorizationKey = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<h1>{authorizationKey}</h1>");
    }




});

app.Run();
