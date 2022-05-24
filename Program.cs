using FactoryMethod;
using FactoryMethod.Implements;
using FactoryMethod.Solution_1;
using FactoryMethod.Solution_2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataUpdate>();
builder.Services.AddScoped<DataNew>();
builder.Services.AddScoped<DataDelete>();
builder.Services.AddScoped<IDataFactory, DataFactory>();
builder.Services.AddServiceSolutionDelegate();
builder.Services.AddServiceSolutionEnum();

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
