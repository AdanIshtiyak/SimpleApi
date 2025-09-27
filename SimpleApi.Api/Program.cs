using Microsoft.EntityFrameworkCore;
using SimpleApi.Services.Interfaces;
using SimpleApi.Services.Persistence;
using SimpleApi.Services.Persistence.Seeders;
using SimpleApi.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IHealthServices, HealthServices>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SimpleDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<SimpleDbContext>();

  db.Database.Migrate();

  var seeder = new DbSeeder(db);
  seeder.Seeder();
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
