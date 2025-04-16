using Microsoft.EntityFrameworkCore;
public class Db : DbContext {
    public DbSet<UserModel> User { get; set; }


    public Db(DbContextOptions<Db> options) : base(options) {

    }
}