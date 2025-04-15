using Microsoft.AspNetCore.Mvc;

public interface IUserController {
    Task<IActionResult> Add([FromBody] UserModel user);
    Task<IActionResult> FindByCpf(string cpf);
    Task<IActionResult> FindAll();
    Task<IActionResult> Update(string cpf, [FromBody] UserModel user);
    Task<IActionResult> Delete(string cpf);
}