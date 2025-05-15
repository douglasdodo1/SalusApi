using Microsoft.AspNetCore.Mvc;

public class AddressService : IAddressService {
  private readonly IAddressRepository _addressRepository;
  private readonly CepValidator _cepValidator;
  public AddressService(IAddressRepository addressRepository, CepValidator cepValidator) {
    _addressRepository = addressRepository;
    _cepValidator = cepValidator;
  }

  public async Task<AddressModel> Add([FromBody] AddressModel address) {
    if (!await _cepValidator.IsValid(address.Cep)) {
      throw new ArgumentException("CEP inválido.");
    }

    if (address.Complemento != "house" && address.Complemento != "apartment") {
      throw new ArgumentException("Complemento inválido.");
    }

    AddressModel existingAddress = await _addressRepository.FindByCep(address.Cep);
    if (existingAddress != null) {
      throw new ArgumentException("Endereço já cadastrado.");
    }

    address.Cep = address.Cep.Replace("-", "").Trim();
    AddressModel addressCreated = await _addressRepository.Add(address);
    return addressCreated;
  }

  public async Task<AddressModel> FindByCep(string cep) {

    if (!await _cepValidator.IsValid(cep)) {
      throw new ArgumentException("CEP inválido.");
    }

    AddressModel address = await _addressRepository.FindByCep(cep);
    if (address == null) {
      throw new ArgumentException("Endereço não encontrado.");
    }
    return address;
  }

  public async Task<List<AddressModel>> FindAll() {
    List<AddressModel> addressList = await _addressRepository.FindAll();
    return addressList;
  }

  public async Task<AddressModel> Update(string cep, [FromBody] AddressModel address) {
    AddressModel findedAddress = await FindByCep(cep);
    if (address.Complemento != "house" && address.Complemento != "apartment") {
      throw new ArgumentException("Complemento inválido.");
    }
    AddressModel updatedAddress = await _addressRepository.Update(address, findedAddress);
    return updatedAddress;
  }
  public async Task<AddressModel> Remove(string cep) {
    AddressModel address = await FindByCep(cep);
    AddressModel deletedAddress = await _addressRepository.Remove(address);
    return deletedAddress;
  }

}