using Microsoft.EntityFrameworkCore;
using RideBooking.API.Middleware;
using RideBooking.Application.Interfaces;
using RideBooking.Application.Services;
using RideBooking.Infrastructure;
using RideBooking.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RideDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IRideRepository, RideRepository>();
builder.Services.AddScoped<IRideService, RideService>();
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();