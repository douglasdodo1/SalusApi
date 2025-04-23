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
    return new CreatedResult($"/Customer/{createdCustomer.Id}", createdCustomer);
  }

  public async Task<IActionResult> FindById(int id) {
    CustomerModel customer = await _customerService.FindById(id);
    return new OkObjectResult(customer);
  }

  public async Task<IActionResult> FindAll() {
    List<CustomerModel> customerList = await _customerService.FindAll();
    return new CreatedResult("/Customer", customerList);
  }

  public async Task<IActionResult> Update(int id, [FromBody] CustomerModel customer) {
    if (customer == null) {
      return new BadRequestObjectResult("Customer cannot be null");
    }

    CustomerModel updatedCustomer = await _customerService.Update(id, customer);
    return new OkObjectResult(updatedCustomer);
  }

  public async Task<IActionResult> Remove(int id) {
    CustomerModel deletedCustomer = await _customerService.Remove(id);
    return new OkObjectResult(deletedCustomer);
  }
}