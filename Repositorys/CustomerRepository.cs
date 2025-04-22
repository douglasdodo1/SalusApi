using Microsoft.EntityFrameworkCore;
public class CustomerRepository : ICustomerRepository{
  private readonly Db _db;
  public CustomerRepository(Db db){
   _db = db;
   }
}