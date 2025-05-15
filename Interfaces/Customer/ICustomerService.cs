using Microsoft.AspNetCore.Mvc;
public interface ICustomerService{
  Task<CustomerModel> Add([FromBody] CustomerModel customer);
  Task<CustomerModel> FindByCpf(string cpf);
  Task<List<CustomerModel>> FindAll();
  Task<CustomerModel> Update(string cpf, [FromBody] CustomerModel customer);
  Task<CustomerModel> Remove(string cpf);
}