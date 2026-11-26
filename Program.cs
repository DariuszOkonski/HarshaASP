var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<MyHomeContoller>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

//app.MapGet("/", () => "Hello World!");



app.Run();
