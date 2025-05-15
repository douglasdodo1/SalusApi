public interface IUserRepository {

    
    Task<UserModel> Add(UserModel user);
    Task<UserModel> FindByCpf(string cpf);
    Task<List<UserModel>> FindAll();
    Task<UserModel> Update(UserModel userToUpdate, UserModel userFinded);
    Task<UserModel> Delete(UserModel user);
}