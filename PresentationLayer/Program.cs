
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Repository;
using DataAcccesLayer.Models;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ModelContext>( opciones => { 
     opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql"));
});

builder.Services.AddScoped<Iproduct, ProductRepository>();
builder.Services.AddScoped<Icategory, CategoryRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080",
                                              "http://localhost:8081",
                                              "http://localhost:4200").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
