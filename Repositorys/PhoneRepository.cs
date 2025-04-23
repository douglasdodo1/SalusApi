using Microsoft.AspNetCore.Mvc;
public class PhoneRepository : IPhoneRepository {
    private readonly Db _db;
    public PhoneRepository(Db db) {
        _db = db;
    }

    public Task<PhoneModel> Add([FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> FindById(int id) {
        throw new NotImplementedException();
    }

    public Task<List<PhoneModel>> FindAll() {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> Remove([FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }

    public Task<PhoneModel> Update([FromBody] PhoneModel phoneToUpdate, [FromBody] PhoneModel phoneFinded) {
        throw new NotImplementedException();
    }
}