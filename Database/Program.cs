// See https://aka.ms/new-console-template for more information
using Database;
using Database.Constants;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
        .AddDbContext<CreatureInfoContext>(options => options.UseSqlite("Data Source=" + DBConstants.DB_NAME))
        .AddScoped<CalcRepository>();

IHost host = builder.Build();


