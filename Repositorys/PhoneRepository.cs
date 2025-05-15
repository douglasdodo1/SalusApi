using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class PhoneRepository : IPhoneRepository{
  private readonly Db _db;
  public PhoneRepository(Db db){
   _db = db;
   }

    public Task<IActionResult> Add([FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> FindAll() {
        throw new NotImplementedException();
    }

    public Task<IActionResult> FindById(int id) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Remove([FromBody] PhoneModel phone) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update([FromBody] PhoneModel phoneToUpdate, [FromBody] PhoneModel phoneFinded) {
        throw new NotImplementedException();
    }
}