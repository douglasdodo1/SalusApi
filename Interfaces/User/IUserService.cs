public interface IUserService {
    Task<UserModel> Add(UserModel user);
    Task<UserModel> FindByCpf(string cpf);
    Task<List<UserModel>> FindAll();
    Task<UserModel> Update(string cpf, UserModel user);
    Task<UserModel> Delete(string cpf);
}