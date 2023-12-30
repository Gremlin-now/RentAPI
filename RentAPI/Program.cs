using RentAPI.Migrations;
using FluentMigrator.Runner;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c
            .AddPostgres()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("PostgreSQL"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);

var app = builder.Build();
app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());

using var serviceprovider = app.Services.CreateScope();

var services = serviceprovider.ServiceProvider;
var runner = services.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
