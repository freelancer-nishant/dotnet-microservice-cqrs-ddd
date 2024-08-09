using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Order.Infrastructure;
using Order.Application;
using Microsoft.OpenApi.Models;
using Order.Infrastructure.Persistence;
using Serilog;
using Common.Logging;
using Order.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using MassTransit;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(conf =>
{
    conf.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]!);
    });
});
builder.Services.Configure<MassTransitHostOptions>(conf =>
{
    conf.WaitUntilStarted = true;
    conf.StartTimeout = TimeSpan.FromSeconds(30);
    conf.StopTimeout = TimeSpan.FromMinutes(1);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Order.API", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddRabbitMQ(builder.Configuration["EventBusSettings:HostAddress"]!,name:"Ordernotification-rabbitmqbus")
    .AddDbContextCheck<OrderContext>();
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();

app.MigrateDatabase<OrderContext>((context, services) =>
{
    var logger = services.GetService<ILogger<OrderContextSeed>>();
    OrderContextSeed
        .SeedAsync(context, logger!)
        .Wait();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.API v1"));
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
