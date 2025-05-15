using Microsoft.AspNetCore.Mvc;
public interface IAddressRepository {
  Task<AddressModel> Add([FromBody] AddressModel address);
  Task<AddressModel> FindByCep(string cep);
  Task<List<AddressModel>> FindAll();
  Task<AddressModel> Update([FromBody] AddressModel addressToUpdate, [FromBody] AddressModel addressFinded);
  Task<AddressModel> Remove([FromBody] AddressModel address);
}