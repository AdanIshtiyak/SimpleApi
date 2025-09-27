using SimpleApi.Services.Interfaces;
using SimpleApi.Services.Persistence;

namespace SimpleApi.Services.Services
{
  public class HealthServices : IHealthServices
  {
    private readonly SimpleDbContext _db;

    public HealthServices(SimpleDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Check the health of the database connection
    /// </summary>
    /// <returns></returns>
    public Task<bool> CheckDatabaseHealth()
    {
      var resilt = _db.Database.CanConnectAsync();

      return resilt;
    }
  }
}
