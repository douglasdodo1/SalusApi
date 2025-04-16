public class UserService : IUserService{
  private readonly UserRepository _userRepository;
  public UserService(UserRepository userRepository){
    _userRepository = userRepository;
   }
}