using Core;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddScoped<HamsterService>();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<HamsterWarsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HamsterWarsConnection")));

var app = builder.Build();

//Creates Database and adds the seed-data on start if it doesn't exist.
using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;

    var context = scopedServices.GetRequiredService<HamsterWarsDbContext>();
    context.Database.EnsureCreated();

    SeedData.Initialize(scopedServices);
}

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
