using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Phone")]
public class PhoneController : IPhoneController {
  private readonly PhoneService _phoneService;
  public PhoneController(PhoneService phoneService) {
    _phoneService = phoneService;
  }

  [HttpPost]
  public async Task<IActionResult> Add([FromBody] PhoneModel phone) {
    if (phone == null) {
      throw new ArgumentNullException(nameof(phone), "Phone cannot be null");
    }
    PhoneModel createdPhone = await _phoneService.Add(phone);
    return new CreatedResult($"/Phone/{createdPhone.Id}", createdPhone);
  }

  public async Task<IActionResult> FindById(int id) {
    if (id <= 0) {
      throw new ArgumentNullException(nameof(id), "Id invalid");
    }
    PhoneModel phone = await _phoneService.FindById(id);
    return new OkObjectResult(phone);
  }

  public async Task<IActionResult> FindAll() {
    List<PhoneModel> phones = await _phoneService.FindAll();
    return new OkObjectResult(phones);
  }

  public async Task<IActionResult> Update(int id, [FromBody] PhoneModel phone) {
    if (id <= 0) {
      throw new ArgumentNullException(nameof(id), "Id invalid");
    }
    if (phone == null) {
      throw new ArgumentNullException(nameof(phone), "Phone cannot be null");
    }
    PhoneModel updatedPhone = await _phoneService.Update(id, phone);
    return new OkObjectResult(updatedPhone);
  }

  public async Task<IActionResult> Remove(int id) {
    if (id <= 0) {
      throw new ArgumentNullException(nameof(id), "Id invalid");
    }
    PhoneModel removedPhone = await _phoneService.Remove(id);
    return new OkObjectResult(removedPhone);
  }
}