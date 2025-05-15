using Microsoft.AspNetCore.Mvc;

public class StateService : IStateService{
  private readonly StateRepository _stateRepository;
  public StateService(StateRepository stateRepository){
    _stateRepository = stateRepository;
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

    public Task<StateModel> Remove(int id) {
        throw new NotImplementedException();
    }

    public Task<StateModel> Update(int id, [FromBody] StateModel state) {
        throw new NotImplementedException();
    }

}