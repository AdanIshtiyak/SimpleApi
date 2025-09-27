namespace SimpleApi.Services.Persistence.Seeders
{
  public partial class DbSeeder
  {
    private SimpleDbContext _db;

    public DbSeeder(SimpleDbContext db)
    {
      _db = db;
    }

    public void Seeder()
    {
      InitUsers();
    }
  }
}
