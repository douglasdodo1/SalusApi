using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Employee")]
public class EmployeeController : IEmployeeController {
  private readonly EmployeeService _employeeService;
  public EmployeeController(EmployeeService employeeService) {
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
  public async Task<IActionResult> FindById(string cpf) {
    EmployeeModel employee = await _employeeService.FindById(cpf);
    return new OkObjectResult(employee);
  }

  [HttpGet]
  public async Task<IActionResult> FindAll() {
    List<EmployeeModel> employeeList = await _employeeService.FindAll();
    return new OkObjectResult(employeeList);
  }

  [HttpPut("{cpf}")]
  public async Task<IActionResult> Update(string cpf, [FromBody] EmployeeModel employee) {
    if (employee == null) {
      throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
    }

    EmployeeModel updatedEmployee = await _employeeService.Update(cpf, employee);
    return new OkObjectResult(updatedEmployee);
  }

  [HttpDelete("{cpf}")]
  public async Task<IActionResult> Remove(string cpf) {
    EmployeeModel employee = await _employeeService.Remove(cpf);
    return new OkObjectResult(employee);
  }
}