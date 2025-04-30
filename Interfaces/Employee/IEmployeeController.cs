using Microsoft.AspNetCore.Mvc;
public interface IEmployeeController {
  Task<IActionResult> Add([FromBody] EmployeeModel employee);
  Task<IActionResult> FindById(string cpf);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(string cpf, [FromBody] EmployeeModel employee);
  Task<IActionResult> Remove(string cpf);
}