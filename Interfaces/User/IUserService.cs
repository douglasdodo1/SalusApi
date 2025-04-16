using Microsoft.AspNetCore.Mvc;
public interface IUserService{
  Task<UserModel> Add([FromBody] UserModel user);
  Task<UserModel> FindByid(int id);
  Task<List<UserModel>> FindAll();
  Task<UserModel> Update(int id, [FromBody] UserModel user);
  Task<UserModel> Remove(int id);
}