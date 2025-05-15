using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Employee")]
public class EmployeeController : IEmployeeController {
  private readonly IEmployeeService _employeeService;
  public EmployeeController(IEmployeeService employeeService) {
    _employeeService = employeeService;
  }

  [HttpPost]
  public async Task<IActionResult> Add([FromBody] EmployeeModel employee) {
    if (employee == null) {
      throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
    }

    EmployeeModel createdEmployee = await _employeeService.Add(employee);
    return new CreatedResult($"/Employee/{createdEmployee.Cpf}", createdEmployee);
  }

  [HttpGet("{cpf}")]
  public async Task<IActionResult> FindByCpf(string cpf) {
    EmployeeModel employee = await _employeeService.FindByCpf(cpf);
    return new OkObjectResult(employee);
  }

  [HttpGet]
  public async Task<IActionResult> FindAll() {
    List<EmployeeModel> employeeList = await _employeeService.FindAll();
    return new OkObjectResult(employeeList);
  }

  [HttpPut("{cpf}")]
  public async Task<IActionResult> Update(string cpf, [FromBody] EmployeeModel employee) {
    Console.WriteLine($"Update: {cpf}");
    Console.WriteLine($"Position: {employee.Position}");
    Console.WriteLine($"Shift:    {employee.Shift}");
    Console.WriteLine($"Name:     {employee.Name ?? "(null)"}");



    EmployeeModel updatedEmployee = await _employeeService.Update(cpf, employee);
    return new OkObjectResult(updatedEmployee);
  }

  [HttpDelete("{cpf}")]
  public async Task<IActionResult> Remove(string cpf) {
    EmployeeModel employee = await _employeeService.Remove(cpf);
    return new OkObjectResult(employee);
  }
}