using Microsoft.AspNetCore.Mvc;
public interface IEmployeeService {
  Task<EmployeeModel> Add([FromBody] EmployeeModel employee);
  Task<EmployeeModel> FindByCpf(string cpf);
  Task<List<EmployeeModel>> FindAll();
  Task<EmployeeModel> Update(string cpf, [FromBody] EmployeeModel employee);
  Task<EmployeeModel> Remove(string cpf);
}