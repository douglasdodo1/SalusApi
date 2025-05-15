using Microsoft.AspNetCore.Mvc;
public interface ICustomerController {
  Task<IActionResult> Add([FromBody] CustomerModel customer);
  Task<IActionResult> FindByCpf(string cpf);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(string cpf, [FromBody] CustomerModel customer);
  Task<IActionResult> Remove(string cpf);
}