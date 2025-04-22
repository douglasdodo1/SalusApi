using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Customer")]
public class CustomerController : ICustomerController{
  private readonly CustomerService _customerService;
  public CustomerController(CustomerService customerService){
    _customerService = customerService;
   }}