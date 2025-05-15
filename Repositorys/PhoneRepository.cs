using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class PhoneRepository : IPhoneRepository {
    private readonly Db _db;
    public PhoneRepository(Db db) {
        _db = db;
    }

    public async Task<PhoneModel> Add([FromBody] PhoneModel phone) {
        PhoneModel createdPhone = (await _db.Phone.AddAsync(phone)).Entity;
        await _db.SaveChangesAsync();
        return createdPhone;
    }

    public async Task<PhoneModel> FindById(int id) {
        PhoneModel phone = await _db.Phone.FindAsync(id) ?? throw new Exception("Phone not found");
        return phone;
    }

    public async Task<List<PhoneModel>> FindAll() {
        List<PhoneModel> phoneList = await _db.Phone.ToListAsync();
        return phoneList;
    }

    public async Task<PhoneModel> Update([FromBody] PhoneModel phoneToUpdate, [FromBody] PhoneModel phoneFinded) {
        phoneFinded.Cpf = phoneToUpdate.Cpf;
        phoneFinded.Number = phoneToUpdate.Number;
        PhoneModel updatedPhone = _db.Phone.Update(phoneFinded).Entity;
        await _db.SaveChangesAsync();
        return updatedPhone;
    }

    public async Task<PhoneModel> Remove([FromBody] PhoneModel phone) {
        PhoneModel phoneDeleted = _db.Phone.Remove(phone).Entity;
        await _db.SaveChangesAsync();
        return phoneDeleted;
    }
}