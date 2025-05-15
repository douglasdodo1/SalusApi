using Microsoft.AspNetCore.Mvc;
public interface ICustomerRepository {
  Task<CustomerModel> Add([FromBody] CustomerModel customer);
  Task<CustomerModel> FindByCpf(string cpf);
  Task<List<CustomerModel>> FindAll();
  Task<CustomerModel> Update([FromBody] CustomerModel customerToUpdate, [FromBody] CustomerModel customerFinded);
  Task<CustomerModel> Remove([FromBody] CustomerModel customer);
}