using Microsoft.AspNetCore.Mvc;

public class CustomerService : ICustomerService {
  private readonly CustomerRepository _customerRepository;
  public CustomerService(CustomerRepository customerRepository) {
    _customerRepository = customerRepository;
  }

  public async Task<CustomerModel> Add([FromBody] CustomerModel customer) {
    UserValidator validator = new UserValidator();
    var validationResult = validator.Validate(customer);
    string erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
    if (!validationResult.IsValid) {
      throw new ArgumentException(erros);
    }

    CustomerModel findedCustomer = await FindById(customer.Id);

    CustomerModel createdCustomer = await _customerRepository.Add(customer);
    return createdCustomer;
  }

  public async Task<CustomerModel> FindById(int id) {
    CustomerModel findedCustomer = await _customerRepository.FindById(id);
    if (findedCustomer == null) {
      throw new KeyNotFoundException("Customer not found");
    }
    return findedCustomer;
  }

  public async Task<List<CustomerModel>> FindAll() {
    List<CustomerModel> customerList = await _customerRepository.FindAll();
    return customerList;
  }

  public async Task<CustomerModel> Update(int id, [FromBody] CustomerModel customer) {


    CustomerModel findedCustomer = await FindById(id);
    CustomerModel updatedCustomer = await _customerRepository.Update(customer, findedCustomer);
    return updatedCustomer;

  }

  public async Task<CustomerModel> Remove(int id) {
    CustomerModel findedCustomer = await FindById(id);
    CustomerModel deletedCustomer = await _customerRepository.Remove(findedCustomer);
    return deletedCustomer;
  }
}