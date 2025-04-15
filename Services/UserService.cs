
public class UserService : IUserService {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public Task<UserModel> Add(UserModel user) {
        throw new NotImplementedException();
    }

    public Task<UserModel> FindByCpf(string cpf) {
        throw new NotImplementedException();
    }

    public Task<List<UserModel>> FindAll() {
        throw new NotImplementedException();
    }

    public Task<UserModel> Update(string cpf, UserModel user) {
        throw new NotImplementedException();
    }

    public Task<UserModel> Delete(string cpf) {
        throw new NotImplementedException();
    }

}