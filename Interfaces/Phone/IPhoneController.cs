using Microsoft.AspNetCore.Mvc;
public interface IPhoneController{
  Task<IActionResult> Add([FromBody] PhoneModel phone);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(int id, [FromBody] PhoneModel phone);
  Task<IActionResult> Remove(int id);
}