using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Employee")]
public class EmployeeController : IEmployeeController{
  private readonly EmployeeService _employeeService;
  public EmployeeController(EmployeeService employeeService){
    _employeeService = employeeService;
   }}