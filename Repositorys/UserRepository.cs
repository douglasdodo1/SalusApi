using Microsoft.EntityFrameworkCore;
public class UserRepository : UserRepository{
  private readonly Db _db;
  public UserRepository(Db db{
   _db = db;
   }
}