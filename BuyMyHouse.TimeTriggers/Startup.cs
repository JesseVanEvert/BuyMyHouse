using BuyMyHouse.BLL;
using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.DAL.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(BuyMyHouse.TimeTriggers.Startup))]
namespace BuyMyHouse.TimeTriggers
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();


            builder.Services.AddScoped<IHouseService, HouseService>();
            builder.Services.AddScoped<IHouseRepository, HouseRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IMortgageService, MortgageService>();
            builder.Services.AddScoped<IEmailService, EmailService>();


            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration["SqlDatabaseConnectionString"]));

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["RedisConnectionString"];
                options.InstanceName = "BuyMyHouse_";
            });
        }
    }
}
