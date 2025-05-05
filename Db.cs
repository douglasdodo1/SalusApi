using Microsoft.EntityFrameworkCore;
public class Db : DbContext {
    public DbSet<UserModel> User { get; set; }
    public DbSet<CustomerModel> Customer { get; set; }
    public DbSet<EmployeeModel> Employee { get; set; }
    public DbSet<PhoneModel> Phone { get; set; }
    public DbSet<AddressModel> Address { get; set; }

    public Db(DbContextOptions<Db> options) : base(options) {

    }
}