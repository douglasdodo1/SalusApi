using Microsoft.AspNetCore.Mvc;
public interface IAddressController {
  Task<IActionResult> Add([FromBody] AddressModel address);
  Task<IActionResult> FindByCep(string cep);
  Task<IActionResult> FindAll();
  Task<IActionResult> Update(string cep, [FromBody] AddressModel address);
  Task<IActionResult> Remove(string cep);
}