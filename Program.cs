using ISP2.Data;
using ISP2.Repositories.ConsultantScreen;
using ISP2.Repositories.LoginScreen;
using ISP2.Repositories.ServiceScreen;
using ISP2.Services.AdminScreen;
using ISP2.Services.LoginScreen;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IConsultantRepository, EfConsultantRepository>();
builder.Services.AddScoped<ITicketRepository, EfTicketRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
