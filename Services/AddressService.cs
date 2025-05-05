using Microsoft.AspNetCore.Mvc;

public class AddressService : CepViaService {
  private readonly AddressRepository _addressRepository;
  public AddressService(AddressRepository addressRepository) {
    _addressRepository = addressRepository;
  }

  public Task<AddressModel> Add([FromBody] AddressModel address) {
    throw new NotImplementedException();
  }

  public Task<List<AddressModel>> FindAll() {
    throw new NotImplementedException();
  }

  public Task<AddressModel> FindByCep(string cep) {
    throw new NotImplementedException();
  }

  public Task<AddressModel> Remove(string cep) {
    throw new NotImplementedException();
  }

  public Task<AddressModel> Update(string cep, [FromBody] AddressModel address) {
    throw new NotImplementedException();
  }
}