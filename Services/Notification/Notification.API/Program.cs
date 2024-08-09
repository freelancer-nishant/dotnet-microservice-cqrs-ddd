using Common.Logging;
using EventBus.Messages.Common;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using notification.API.Data.Interfaces;
using notification.API.EventBusConsumer;
using notification.API.Repositories;
using notification.API.Repositories.Interfaces;
using notification.API.Services;
using notification.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(conf =>
{
    conf.AddConsumer<OrderNotificationConsumer>();
    conf.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]!);
        cfg.ReceiveEndpoint(EventBusConstants.OrdernotificationQueue, c =>
        {
            c.ConfigureConsumer<OrderNotificationConsumer>(ctx);
        });
    });
});
builder.Services.Configure<MassTransitHostOptions>(conf =>
{
    conf.WaitUntilStarted = true;
    conf.StartTimeout = TimeSpan.FromSeconds(30);
    conf.StopTimeout = TimeSpan.FromMinutes(1);
});
builder.Services.AddScoped<OrderNotificationConsumer>();
builder.Services.AddScoped<INotificationContext, notification.API.Data.NotificationContext>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "notification.API", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddRabbitMQ(builder.Configuration["EventBusSettings:HostAddress"]!, name: "Ordernotification-rabbitmqbus")
    .AddMongoDb(builder.Configuration["DatabaseSettings:ConnectionString"]!, "MongoDb Health", HealthStatus.Degraded);
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "notification.API v1"));
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
