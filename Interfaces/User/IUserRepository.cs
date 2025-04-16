using Microsoft.AspNetCore.Mvc;
public interface IUserRepository{
  Task<IActionResult> Add([FromBody] UserModel user);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update([FromBody] UserModel userToUpdate, [FromBody] UserModel userFinded);
  Task<IActionResult> Remove([FromBody] UserModel user);
}