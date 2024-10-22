
using CongestionTaxCalculator.Api;
using CongestionTaxCalculator.Api.Infrastructure;
using CongestionTaxCalculator.Application;
using CongestionTaxCalculator.Application.CalculateTax.Query;
using CongestionTaxCalculator.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();


app.MapGet("/TaxCalculator",
    async (ISender sender, string vehicleType, string cityName, DateTime[] dates) =>
        await sender.Send(new GetTaxVehicleQuery(vehicleType, cityName, dates))
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUi();
}

app.UseAuthorization();


app.Run();
