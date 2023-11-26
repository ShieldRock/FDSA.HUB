using FDSA.Application.Interfaces;
using FDSA.Application.Interfaces.WebServices;
using FDSA.Infraestructure;
using FDSA.Infraestructure.WebServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHubService, HubService>();
builder.Services.AddScoped<IHotelLegsService, HotelLegsService>();
builder.Services.AddScoped<ISpeediaService, SpeediaService>();
builder.Services.AddScoped<IHotelLegsAPI, HotelLegsAPI>();

RegisterHttpClients(builder);

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


static void RegisterHttpClients(WebApplicationBuilder builder)
{
    builder.Services.AddHttpClient("HotelLegs", client =>
    {
        client.BaseAddress = new Uri("https://localhost:7289/");
    });
    //builder.Services.AddHttpClient("TravelDoorX", client =>
    //{
    //    client.BaseAddress = new Uri("https://localhost:44364/");
    //});
    //builder.Services.AddHttpClient("Speedia", client =>
    //{
    //    client.BaseAddress = new Uri("https://localhost:44365/");
    //});
}