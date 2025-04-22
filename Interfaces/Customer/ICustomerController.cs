using Microsoft.AspNetCore.Mvc;
public interface ICustomerController{
  Task<IActionResult> Add([FromBody] CustomerModel customer);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(int id, [FromBody] CustomerModel customer);
  Task<IActionResult> Remove(int id);
}