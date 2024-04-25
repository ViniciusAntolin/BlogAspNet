using Blog.Data;
using Data.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IDbContext, BlogDataContext>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();