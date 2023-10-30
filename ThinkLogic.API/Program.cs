using Microsoft.Extensions.Configuration;
using ThinkLogic.Common.Models;
using ThinkLogic.Domain.Common;
using ThinkLogic.Domain.Implementations.Business;
using ThinkLogic.Domain.Implementations.Repository;
using ThinkLogic.Domain.Implementations.Validator;
using ThinkLogic.Domain.Interfaces.Business;
using ThinkLogic.Domain.Interfaces.Repository;
using ThinkLogic.Domain.Interfaces.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(x => 
    builder.Configuration.GetSection("DbContextConfig").Get<ThinkLogicDatabaseContextOptions>()!);

builder.Services.AddTransient<ThinkLogicDatabaseContext>();
builder.Services.AddTransient<IBusiness<ScheduledEvent>, ScheduledEventBusiness>();
builder.Services.AddTransient<IRepository<ScheduledEvent>, ScheduledEventRepository>();
builder.Services.AddTransient<IValidator<ScheduledEvent>, ScheduledEventValidator>();



builder.Services.AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
