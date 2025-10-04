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

var isNeedRunSeeders = builder.Configuration.GetValue("IS_NEED_RUN_SEEDERS", false);

if (isNeedRunSeeders)
{
  using (var scope = app.Services.CreateScope())
  {
    var db = scope.ServiceProvider.GetRequiredService<SimpleDbContext>();

    await db.Database.MigrateAsync();

    var seeder = new DbSeeder(db);
    seeder.Seeder();
  }
}

// Configure the HTTP request pipeline.

var isNeedSwagger = builder.Configuration.GetValue("IS_NEED_SWAGGER", true);

if ()
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
