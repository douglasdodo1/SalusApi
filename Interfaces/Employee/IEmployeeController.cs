using Microsoft.AspNetCore.Mvc;
public interface IEmployeeController{
  Task<IActionResult> Add([FromBody] EmployeeModel employee);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(int id, [FromBody] EmployeeModel employee);
  Task<IActionResult> Remove(int id);
}