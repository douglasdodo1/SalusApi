using Microsoft.AspNetCore.Mvc;
public interface CepViaService {
  Task<AddressModel> Add([FromBody] AddressModel address);
  Task<AddressModel> FindByCep(string cep);
  Task<List<AddressModel>> FindAll();
  Task<AddressModel> Update(string cep, [FromBody] AddressModel address);
  Task<AddressModel> Remove(string cep);
}