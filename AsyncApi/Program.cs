using System.Globalization;
using System.Reflection;
using AsyncApi.Infrastructure.Database;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Serilog;

var culture = new CultureInfo("es-MX");
Thread.CurrentThread.CurrentCulture = culture;
Thread.CurrentThread.CurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom
        .Configuration(context.Configuration.GetSection("Infrastructure"), "Logging");
});

builder.Services.AddLocalization();
builder.Services.AddDatabase();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidation(configuration =>
{
    configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddHangfire(configuration => configuration.UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.IsNested ? $"{type.DeclaringType?.Name}{type.Name}" : type.Name);
});

var app = builder.Build();

app.UseRequestLocalization();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();