using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connString = builder.Configuration.GetConnectionString("MiniProduction");
        if (connString == null)
        {
            Console.WriteLine("There is no ConnectionString called MiniProduction in appsettings.json");
        }
        else
        {
            builder.Services.AddDbContext<MiniProductionDbContext>(options => options.UseSqlServer(connString));
            builder.Services.AddScoped<DbContext, MiniProductionDbContext>();
            builder.Services.AddScoped<DatabaseRepo<Machine>>();
            builder.Services.AddScoped<DatabaseRepo<Order>>();
            builder.Services.AddScoped<DatabaseRepo<Parameter>>();
            builder.Services.AddScoped<DatabaseRepo<Process>>();
            builder.Services.AddScoped<DatabaseRepo<ProcessParameter>>();
            builder.Services.AddScoped<DatabaseRepo<ProcessStatus>>();
            builder.Services.AddScoped<DatabaseRepo<Product>>();
            builder.Services.AddControllersWithViews();
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}