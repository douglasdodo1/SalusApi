using Microsoft.AspNetCore.Mvc;
public interface IPhoneService {
  Task<PhoneModel> Add([FromBody] PhoneModel phone);
  Task<PhoneModel> FindById(int id);
  Task<List<PhoneModel>> FindAll();
  Task<PhoneModel> Update(int id, [FromBody] PhoneModel phone);
  Task<PhoneModel> Remove(int id);
}