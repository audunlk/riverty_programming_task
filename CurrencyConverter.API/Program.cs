using CurrencyConverter.API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add the connection string to the database
//Add ReferenceLoopHandling to ignore the circular reference error
//add cors exception localhost:3000

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
       .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

});
builder.Services.AddDbContext<ExchangeRateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
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

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
