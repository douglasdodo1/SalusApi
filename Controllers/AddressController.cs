using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Address")]
public class AddressController : IAddressController {
  private readonly AddressService _addressService;
  public AddressController(AddressService addressService) {
    _addressService = addressService;
  }

  public async Task<IActionResult> Add([FromBody] AddressModel address) {
    if (address == null) {
      throw new ArgumentNullException(nameof(address), "Address cannot be null");
    }
    AddressModel createdAddress = await _addressService.Add(address);
    return new CreatedResult($"/Address/{createdAddress.Cep}", createdAddress);
  }

  public async Task<IActionResult> FindByCep(string cep) {
    AddressModel address = await _addressService.FindByCep(cep);
    return new OkObjectResult(address);
  }

  public async Task<IActionResult> FindAll() {
    List<AddressModel> addressList = await _addressService.FindAll();
    return new OkObjectResult(addressList);
  }

  public async Task<IActionResult> Update(string cep, [FromBody] AddressModel address) {
    if (address == null) {
      throw new ArgumentNullException(nameof(address), "Address cannot be null");
    }
    AddressModel updatedAddress = await _addressService.Update(cep, address);
    return new OkObjectResult(updatedAddress);
  }

  public async Task<IActionResult> Remove(string cep) {
    AddressModel addressModel = await _addressService.Remove(cep);
    return new OkObjectResult(addressModel);
  }
}