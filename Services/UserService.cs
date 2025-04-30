
using Microsoft.AspNetCore.Mvc;

public class UserService : IUserService {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Add(UserModel user) {
        UserValidator userValidator = new UserValidator();
        var result = userValidator.Validate(user);
        string errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));

        if (!result.IsValid) {
            throw new ArgumentException(errors);
        }

        UserModel findedUser = await FindByCpf(user.Cpf);
        if (findedUser != null) {
            throw new ArgumentException("User already exists");
        }
        UserModel createdUser = await _userRepository.Add(user);

        return createdUser;
    }

    public async Task<UserModel> FindByCpf(string cpf) {
        UserModel findedUser = await _userRepository.FindByCpf(cpf);
        if (findedUser == null) {
            throw new KeyNotFoundException("User not found");
        }

        return findedUser;
    }

    public async Task<List<UserModel>> FindAll() {
        List<UserModel> users = await _userRepository.FindAll();
        return users;
    }

    public async Task<UserModel> Update(string cpf, UserModel userToUpdate) {
        UserModel findedUser = await _userRepository.FindByCpf(cpf);
        UserValidator userValidator = new UserValidator();
        var result = userValidator.Validate(userToUpdate);
        string errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));

        if (!result.IsValid) {
            throw new ArgumentException(errors);
        }

        UserModel updatedUser = await _userRepository.Update(userToUpdate, findedUser);

        return updatedUser;
    }

    public async Task<UserModel> Delete(string cpf) {
        UserModel findedUser = await _userRepository.FindByCpf(cpf);
        UserModel deletedUser = await _userRepository.Delete(findedUser);
        return deletedUser;
    }

}