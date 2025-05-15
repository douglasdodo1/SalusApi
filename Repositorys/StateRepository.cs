using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class StateRepository : IStateRepository{
  private readonly Db _db;
  public StateRepository(Db db){
   _db = db;
   }

    public Task<StateModel> Add([FromBody] StateModel state) {
        throw new NotImplementedException();
    }

    public Task<List<StateModel>> FindAll() {
        throw new NotImplementedException();
    }

    public Task<StateModel> FindById(int id) {
        throw new NotImplementedException();
    }

    public Task<StateModel> Remove([FromBody] StateModel state) {
        throw new NotImplementedException();
    }

    public Task<StateModel> Update([FromBody] StateModel stateToUpdate, [FromBody] StateModel stateFinded) {
        throw new NotImplementedException();
    }

}