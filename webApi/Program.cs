using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webApi.Repositories;
using webApi.Repositories.Interfaces;
using webApi.Services;
using webApi.Services.Interfaces;
using webApi.StoreSampleContext;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("webApi");

// Configurar el DbContext con la cadena de conexión
builder.Services.AddDbContext<StoreSampleContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOrdersRepository,OrdersRepository>();
builder.Services.AddScoped<IOrderService, OrdersService>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesService, EmployesService>();
builder.Services.AddScoped<IShippersRepository, ShippersRepository>();
builder.Services.AddScoped<IShipperService, ShippersService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IPredictionsRepository, PredictionRepository>();
builder.Services.AddScoped<IPredictionsService, PredictionsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("corsPolicy");


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
