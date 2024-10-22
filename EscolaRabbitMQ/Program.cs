using EscolaRabbitMQ.Controllers;
using EscolaRabbitMQ.Data;
using EscolaRabbitMQ.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDb>(
                       options =>
                       {
                           var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                           string password = builder.Configuration["PasswordDb:password"]!;

                           if (string.IsNullOrEmpty(password))
                           {
                               throw new InvalidOperationException("Environment variable SA_PASSWORD is not set.");
                           }

                           connectionString = string.Format(connectionString!, password);

                           options.UseSqlServer(connectionString);

                       });

builder.Services.AddRegisterServices(builder.Configuration);

var app = builder.Build();

app.AddApiEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextDb>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.Run();
