using Microsoft.AspNetCore.Mvc;
public interface IStateController{
  Task<IActionResult> Add([FromBody] StateModel state);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(int id, [FromBody] StateModel state);
  Task<IActionResult> Remove(int id);
}