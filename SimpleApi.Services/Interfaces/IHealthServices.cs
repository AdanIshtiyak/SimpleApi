namespace SimpleApi.Services.Interfaces
{
  public interface IHealthServices
  {
    Task<bool> CheckDatabaseHealth();
  }
}
