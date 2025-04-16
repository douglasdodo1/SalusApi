using Microsoft.AspNetCore.Mvc;
public interface IPhoneRepository{
  Task<IActionResult> Add([FromBody] PhoneModel phone);
  Task<IActionResult> FindById(int id);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update([FromBody] PhoneModel phoneToUpdate, [FromBody] PhoneModel phoneFinded);
  Task<IActionResult> Remove([FromBody] PhoneModel phone);
}