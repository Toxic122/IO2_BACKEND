using Microsoft.EntityFrameworkCore;
using ISP2.Data;
using ISP2.Repositories.LoginScreen;
using ISP2.Services.LoginScreen;

var builder = WebApplication.CreateBuilder(args);

// Dodaj EF Core z SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj repozytoria i serwisy
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

// Dodaj Swaggera
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// U¿yj Swaggera tylko w trybie developerskim
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
