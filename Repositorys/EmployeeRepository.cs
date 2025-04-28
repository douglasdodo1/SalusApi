using Microsoft.EntityFrameworkCore;
public class EmployeeRepository : IEmployeeRepository{
  private readonly Db _db;
  public EmployeeRepository(Db db){
   _db = db;
   }
}