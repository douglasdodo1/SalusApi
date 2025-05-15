using Microsoft.AspNetCore.Mvc;
public interface IStateRepository{
  Task<StateModel> Add([FromBody] StateModel state);
  Task<StateModel> FindById(int id);
  Task<List<StateModel>> FindAll();
  Task<StateModel> Update([FromBody] StateModel stateToUpdate, [FromBody] StateModel stateFinded);
  Task<StateModel> Remove([FromBody] StateModel state);
}