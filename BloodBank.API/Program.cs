using BloodBank.API.ExtensionMethods;
using BloodBank.Application;
using BloodBank.Infrastructure;
using FastReport.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddFastReport();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();
app.UseFastReport();
app.MapControllers();

app.Run();
