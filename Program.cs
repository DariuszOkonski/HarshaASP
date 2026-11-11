var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
});

app.Map("employee/profile/{employeename}", async context =>
{
    string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);

    await context.Response.WriteAsync($"response - {employeename}");
});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();