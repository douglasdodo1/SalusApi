using Microsoft.AspNetCore.Mvc;
public interface IEmployeeRepository {
  Task<EmployeeModel> Add([FromBody] EmployeeModel employee);
  Task<EmployeeModel> FindById(string cpf);
  Task<List<EmployeeModel>> FindAll();
  Task<EmployeeModel> Update([FromBody] EmployeeModel employeeToUpdate, [FromBody] EmployeeModel employeeFinded);
  Task<EmployeeModel> Remove([FromBody] EmployeeModel employee);
}