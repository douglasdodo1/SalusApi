using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("User")]
public class UserController : IUserController{
  private readonly UserService _userService;
  public UserController(UserService userService){
    _userService = userService;
   }}