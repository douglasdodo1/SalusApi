using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class AddressRepository : IAddressRepository {
  private readonly Db _db;
  public AddressRepository(Db db) {
    _db = db;
  }

  public async Task<AddressModel> Add([FromBody] AddressModel address) {
    AddressModel addressCreated = (await _db.Address.AddAsync(address)).Entity;
    await _db.SaveChangesAsync();
    return addressCreated;
  }

  public async Task<AddressModel> FindByCep(string cep) {
    AddressModel address = await _db.Address.FindAsync(cep) ?? throw new Exception("Address not found");
    return address;
  }

  public async Task<List<AddressModel>> FindAll() {
    List<AddressModel> addressList = await _db.Address.ToListAsync();
    return addressList;
  }

  public async Task<AddressModel> Remove([FromBody] AddressModel address) {
    AddressModel addressDeleted = _db.Address.Remove(address).Entity;
    await _db.SaveChangesAsync();
    return addressDeleted;
  }

  public async Task<AddressModel> Update([FromBody] AddressModel addressToUpdate, [FromBody] AddressModel addressFinded) {
    addressFinded.Cep = !string.IsNullOrEmpty(addressToUpdate.Cep) ? addressToUpdate.Cep : addressFinded.Cep;
    addressFinded.RuaId = addressToUpdate.RuaId != -1 ? addressToUpdate.RuaId : addressFinded.RuaId;
    addressFinded.Complemento = !string.IsNullOrEmpty(addressToUpdate.Complemento) ? addressToUpdate.Complemento : addressFinded.Complemento;

    await _db.SaveChangesAsync();
    return addressFinded;
  }
}