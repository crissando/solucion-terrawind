using api_terrawind.Context;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
