using Microsoft.AspNetCore.Mvc;
public interface IPhoneRepository {
  Task<PhoneModel> Add([FromBody] PhoneModel phone);
  Task<PhoneModel> FindById(int id);
  Task<List<PhoneModel>> FindAll();
  Task<PhoneModel> Update([FromBody] PhoneModel phoneToUpdate, [FromBody] PhoneModel phoneFinded);
  Task<PhoneModel> Remove([FromBody] PhoneModel phone);
}