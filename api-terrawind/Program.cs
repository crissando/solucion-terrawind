using api_terrawind.Infraestructure.Interfaces;
using api_terrawind.Infraestructure.Persistence.Context;
using api_terrawind.Application.Interfaces;
using api_terrawind.Application.UseCases;
using Microsoft.EntityFrameworkCore;
using api_terrawind.Infraestructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .WithOrigins("http://localhost:3000", "http://localhost:5173")
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddHttpClient();

//Infraestructure
builder.Services.AddScoped<ICryptoCurrencyRepository, CryptoCurrencyRepository>();

//Aplication
builder.Services.AddScoped<IGetCryptoCurrenciesUseCase, GetCryptoCurrenciesUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
