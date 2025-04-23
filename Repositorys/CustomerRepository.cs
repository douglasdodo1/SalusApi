using Microsoft.AspNetCore.Mvc;
public class CustomerRepository : ICustomerRepository {
  private readonly Db _db;
  public CustomerRepository(Db db) {
    _db = db;
  }

  public Task<CustomerModel> Add([FromBody] CustomerModel customer) {
    throw new NotImplementedException();
  }

  public Task<List<CustomerModel>> FindAll() {
    throw new NotImplementedException();
  }

  public Task<CustomerModel> FindById(int id) {
    throw new NotImplementedException();
  }

  public Task<CustomerModel> Remove([FromBody] CustomerModel customer) {
    throw new NotImplementedException();
  }

  public Task<CustomerModel> Update([FromBody] CustomerModel customerToUpdate, [FromBody] CustomerModel customerFinded) {
    throw new NotImplementedException();
  }
}