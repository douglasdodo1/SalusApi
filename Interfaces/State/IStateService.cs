using Microsoft.AspNetCore.Mvc;
public interface IStateService{
  Task<StateModel> Add([FromBody] StateModel state);
  Task<StateModel> FindById(int id);
  Task<List<StateModel>> FindAll();
  Task<StateModel> Update(int id, [FromBody] StateModel state);
  Task<StateModel> Remove(int id);
}