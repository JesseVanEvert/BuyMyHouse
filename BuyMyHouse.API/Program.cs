using BuyMyHouse.BLL;
using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IMortgageService, MortgageService>();
builder.Services.AddSingleton<IPdfRepository>(new PdfRepository(configuration["pdfBlobConnectionString"], configuration["pdfBlobContainer"]));


builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(configuration["SqlDatabaseConnectionString"]));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration["RedisConnectionString"];
    options.InstanceName = "BuyMyHouse_";
});


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



