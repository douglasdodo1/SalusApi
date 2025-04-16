using Microsoft.AspNetCore.Mvc;
public interface IUserController{
  Task<IActionResult> Add([FromBody] UserModel user);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(int id, [FromBody] UserModel user);
  Task<IActionResult> Remove(int id);
}