using BloodBank.API.Filters;
using BloodBank.Application.Commands.CreateBloodStock;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBloodStockCommand>());

var connectionString = builder.Configuration.GetConnectionString("BloodBank");
builder.Services.AddDbContext<BloodBankDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddMediatR(typeof(CreateBloodStockCommand));
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
