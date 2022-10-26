using Microsoft.Extensions.Options;
using MongoDB.Driver;
using fuelWebAPI.Models;
using fuelWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FuelStationDBSettings>(
    builder.Configuration.GetSection(nameof(FuelStationDBSettings)));

builder.Services.AddSingleton<IFuelStationDBSettings>(sp =>
sp.GetRequiredService<IOptions<FuelStationDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => 
new MongoClient(builder.Configuration.GetValue<string>("FuelStationDBSettings:ConnectionString")));

builder.Services.AddScoped<IFuelStationService, FuelStationService>();
builder.Services.AddScoped<IFuelQueueService, FuelQueueService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
