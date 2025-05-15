using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("State")]
public class StateController : IStateController{
  private readonly StateService _stateService;
  public StateController(StateService stateService){
    _stateService = stateService;
   }

    public Task<IActionResult> Add([FromBody] StateModel state) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> FindAll() {
        throw new NotImplementedException();
    }

    public Task<IActionResult> FindById(int id) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Remove(int id) {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, [FromBody] StateModel state) {
        throw new NotImplementedException();
    }
}