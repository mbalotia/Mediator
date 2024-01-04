using ClientMinimalAPI;
using ClientMinimalAPI.Handlers;
using ClientMinimalAPI.Models;
using ClientMinimalAPI.Services;
using libCustomMediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediator(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient<IBooking, svcBooking>();
// Add services to the container.
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


app.MapGet("/bookings/{Id}", async ([FromQuery] int Id, IMediator mediator) =>
{
    var bookings = await mediator.Send(new GetBookingsQuery(Id));
    return TypedResults.Ok(bookings);
})
.WithOpenApi();

app.MapPost("/bookings", async ([FromBody] Booking booking, IMediator mediator) =>
{
    var bookings = await mediator.Send(new AddBookingCommand(booking));
    return TypedResults.Ok(bookings);
})
.WithOpenApi();

app.MapPost("/weatherforecast", async ([FromBody] WeatherForecastRequest request, IMediator mediator) =>
{
    var weatherForecast = await mediator.Send(request);
    return TypedResults.Ok(weatherForecast);
})

.WithOpenApi();

app.Run();


