using Microsoft.EntityFrameworkCore;
using REngine2.config;
using REngine2.repository;
using REngine2.service;
using REngine2.service.impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<REngineDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("Default");
    
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://87aec05c74e0e84f1e29554b55aaab2c@o4507592246951936.ingest.us.sentry.io/4507599183216640";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
});

// Repositories
builder.Services.AddScoped<HotelRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<EngineRepository>();

// Services
builder.Services.AddScoped<IHotelService, HotelServiceImpl>();
builder.Services.AddScoped<IRoomService, RoomServiceImpl>();
builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<IReservationService, ReservationServiceImpl>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.HeadContent = "<style>.curl-command {display:none}</style>"; });
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();