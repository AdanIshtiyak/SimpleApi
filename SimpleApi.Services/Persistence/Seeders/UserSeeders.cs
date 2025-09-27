using SimpleApi.Services.Models;

namespace SimpleApi.Services.Persistence.Seeders
{
  public partial class DbSeeder
  {
    private void InitUsers()
    {
      if (_db.Users.Any(c => !c.IsDeleted))
        return;

      var users = new List<User>()
      {
        new User
        {
          Name = "Alice"
        },
        new User
        {
          Name = "Bob"
        },
        new User
        {
          Name = "Charlie"
        },
        new User
        {
          Name = "David"
        },
        new User
        {
          Name = "Eve"
        }
      };

      _db.Users.AddRange(users);
      _db.SaveChanges();
    }
  }
}
