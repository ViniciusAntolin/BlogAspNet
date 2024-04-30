using Blog.Data;
using Data.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<IDbContext, BlogDataContext>();

var app = builder.Build();
app.MapControllers();

app.Run();