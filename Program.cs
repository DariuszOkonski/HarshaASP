var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<MyHomeContoller>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");



app.Run();
