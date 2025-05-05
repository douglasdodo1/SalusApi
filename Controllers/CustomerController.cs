using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Customer")]
public class CustomerController : ICustomerController {
  private readonly CustomerService _customerService;
  public CustomerController(CustomerService customerService) {
    _customerService = customerService;
  }

  public async Task<IActionResult> Add([FromBody] CustomerModel customer) {
    if (customer == null) {
      return new BadRequestObjectResult("Customer cannot be null");
    }

    CustomerModel createdCustomer = await _customerService.Add(customer);
    return new CreatedResult($"/Customer/{createdCustomer.Cpf}", createdCustomer);
  }

  public async Task<IActionResult> FindByCpf(string cpf) {
    CustomerModel customer = await _customerService.FindByCpf(cpf);
    return new OkObjectResult(customer);
  }

  public async Task<IActionResult> FindAll() {
    List<CustomerModel> customerList = await _customerService.FindAll();
    return new CreatedResult("/Customer", customerList);
  }

  public async Task<IActionResult> Update(string cpf, [FromBody] CustomerModel customer) {
    if (customer == null) {
      return new BadRequestObjectResult("Customer cannot be null");
    }

    CustomerModel updatedCustomer = await _customerService.Update(cpf, customer);
    return new OkObjectResult(updatedCustomer);
  }

  public async Task<IActionResult> Remove(string cpf) {
    CustomerModel deletedCustomer = await _customerService.Remove(cpf);
    return new OkObjectResult(deletedCustomer);
  }
}