public class EmployeeService : IEmployeeService{
  private readonly EmployeeRepository _employeeRepository;
  public EmployeeService(EmployeeRepository employeeRepository){
    _employeeRepository = employeeRepository;
   }
}