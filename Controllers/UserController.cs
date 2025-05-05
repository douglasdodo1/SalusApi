using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("User")]
public class UserController : IUserController {

    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserModel user) {
        if (user == null) {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        UserModel createdUser = await _userService.Add(user);
        return new CreatedResult($"/User/{createdUser.Cpf}", createdUser);
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> FindByCpf(string cpf) {
        if (cpf == null) {
            throw new ArgumentNullException(nameof(cpf), "Cpf cannot be null");
        }
        UserModel user = await _userService.FindByCpf(cpf);
        return new OkObjectResult(user);
    }

    [HttpGet]
    public async Task<IActionResult> FindAll() {
        List<UserModel> userList = await _userService.FindAll();
        return new CreatedResult("/User", userList);
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> Update(string cpf, [FromBody] UserModel user) {
        if (user == null) {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }
        if (cpf == null) {
            throw new ArgumentNullException(nameof(cpf), "Cpf cannot be null");
        }
        UserModel updatedUser = await _userService.Update(cpf, user);
        return new CreatedResult($"/User/{updatedUser.Cpf}", updatedUser);
    }

    [HttpDelete("{cpf}")]
    public async Task<IActionResult> Delete(string cpf) {
        if (cpf == null) {
            throw new ArgumentNullException(nameof(cpf), "Cpf cannot be null");
        }
        UserModel deletedUser = await _userService.Delete(cpf);
        return new OkObjectResult(deletedUser);
    }
}