public class CustomerService : ICustomerService{
  private readonly CustomerRepository _customerRepository;
  public CustomerService(CustomerRepository customerRepository){
    _customerRepository = customerRepository;
   }
}