
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository {

    private readonly Db _db;
    public UserRepository(Db db) {
        _db = db;
    }

    public async Task<UserModel> Add(UserModel user) {
        UserModel createdUser = (await _db.User.AddAsync(user)).Entity;
        await _db.SaveChangesAsync();
        return createdUser;
    }

    public async Task<UserModel> FindByCpf(string cpf) {
        UserModel user = await _db.User.FindAsync(cpf) ?? throw new Exception("User not found");
        return user;
    }

    public async Task<List<UserModel>> FindAll() {
        List<UserModel> userList = await _db.User.ToListAsync();
        return userList;
    }

    public async Task<UserModel> Update(UserModel userToUpdate, UserModel userFinded) {
        userFinded.Name = userToUpdate.Name;
        userFinded.Email = userToUpdate.Email;
        userFinded.Password = userToUpdate.Password;

        await _db.SaveChangesAsync();
        return userFinded;
    }

    public async Task<UserModel> Delete(UserModel user) {
        UserModel userDeleted = _db.User.Remove(user).Entity;
        await _db.SaveChangesAsync();
        return userDeleted;
    }

}