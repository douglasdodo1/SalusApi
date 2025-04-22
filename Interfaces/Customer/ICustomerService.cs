using Microsoft.AspNetCore.Mvc;
public interface ICustomerService{
  Task<CustomerModel> Add([FromBody] CustomerModel customer);
  Task<CustomerModel> FindById(int id);
  Task<List<CustomerModel>> FindAll();
  Task<CustomerModel> Update(int id, [FromBody] CustomerModel customer);
  Task<CustomerModel> Remove(int id);
}