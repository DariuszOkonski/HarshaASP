using HarshaASP.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});

var app = builder.Build();

app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
});

app.Map("employee/profile/{EmployeeName:length(3,7):alpha=scott}", async context =>
{
    string? employeeName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);

    await context.Response.WriteAsync($"response - {employeeName}");
});

app.Map("products/details/{id:int:min(1):max(100)}", async context =>
{
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product details - {id}");
    }
    else
    {
        await context.Response.WriteAsync("id is not supplied");
    }

});

app.Map("daily-digest-report/{reportdate:datetime}", async context =>
{
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);

    await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
});

app.Map("cities/{cityid:guid}", async (context) =>
{
    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);

    await context.Response.WriteAsync($"City information - {cityId}");
});

app.Map("sales-report/{year:int:min(1900)}/{month:months}", async (context) =>
{
    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
    string? month = Convert.ToString(context.Request.RouteValues["month"]);

    if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
    {
        await context.Response.WriteAsync($"sales report - {year} = {month}");
    }
    else
    {
        await context.Response.WriteAsync($"{month} month is not allowed for sales report");
    }

});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync($"FALLBACK No route matched at {context.Request.Path}");
});

app.Run();