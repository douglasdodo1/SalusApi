using Microsoft.AspNetCore.Mvc;

public class PhoneService : IPhoneService{
  private readonly PhoneRepository _phoneRepository;
  public PhoneService(PhoneRepository phoneRepository){
    _phoneRepository = phoneRepository;
   }

    public Task<PhoneModel> Add([FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }

    public Task<List<PhoneModel>> FindAll() {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> FindById(int id) {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> Remove(int id) {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> Update(int id, [FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }
}