using Microsoft.AspNetCore.Mvc;
public interface IEmployeeService{
  Task<EmployeeModel> Add([FromBody] EmployeeModel employee);
  Task<EmployeeModel> FindById(int id);
  Task<List<EmployeeModel>> FindAll();
  Task<EmployeeModel> Update(int id, [FromBody] EmployeeModel employee);
  Task<EmployeeModel> Remove(int id);
}