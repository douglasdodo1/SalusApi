using Microsoft.EntityFrameworkCore;
public class AddressRepository : IAddressRepository{
  private readonly Db _db;
  public AddressRepository(Db db){
   _db = db;
   }
}