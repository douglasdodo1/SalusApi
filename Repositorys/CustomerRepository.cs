using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class CustomerRepository : ICustomerRepository {
  private readonly Db _db;
  public CustomerRepository(Db db) {
    _db = db;
  }

  public async Task<CustomerModel> Add([FromBody] CustomerModel customer) {
    CustomerModel createdCustomer = (await _db.Customer.AddAsync(customer)).Entity;
    await _db.SaveChangesAsync();
    return createdCustomer;
  }

  public async Task<CustomerModel> FindByCpf(string cpf) {
    CustomerModel customer = await _db.Customer.FindAsync(cpf) ?? throw new Exception("Customer not found");
    return customer;
  }

  public async Task<List<CustomerModel>> FindAll() {
    List<CustomerModel> customerList = await _db.Customer.ToListAsync();
    return customerList;
  }

  public async Task<CustomerModel> Update([FromBody] CustomerModel customerToUpdate, [FromBody] CustomerModel customerFinded) {
    customerFinded.Name = customerToUpdate.Name;
    customerFinded.Email = customerToUpdate.Email;
    customerFinded.Password = customerToUpdate.Password;
    customerFinded.Cpf = customerToUpdate.Cpf;


    await _db.SaveChangesAsync();
    return customerFinded;
  }

  public async Task<CustomerModel> Remove([FromBody] CustomerModel customer) {
    CustomerModel customerDeleted = _db.Customer.Remove(customer).Entity;
    await _db.SaveChangesAsync();
    return customerDeleted;
  }

}