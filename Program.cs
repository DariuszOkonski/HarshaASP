var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
});

app.Map("employee/profile/{employeename=scott}", async context =>
{
    string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);

    await context.Response.WriteAsync($"response - {employeename}");
});

app.Map("products/details/{id?}", async context =>
{
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product details - {id}");
    }
    else
    {

        await context.Response.WriteAsync("id is not supplied");
    }

});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync($"FALLBACK Request received at {context.Request.Path}");
});

app.Run();