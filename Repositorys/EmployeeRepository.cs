using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class EmployeeRepository : IEmployeeRepository{
  private readonly Db _db;
  public EmployeeRepository(Db db){
   _db = db;
   }

    public Task<EmployeeModel> Add([FromBody] EmployeeModel employee) {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeModel>> FindAll() {
        throw new NotImplementedException();
    }

    public Task<EmployeeModel> FindById(string cpf) {
        throw new NotImplementedException();
    }

    public Task<EmployeeModel> Remove([FromBody] EmployeeModel employee) {
        throw new NotImplementedException();
    }

    public Task<EmployeeModel> Update([FromBody] EmployeeModel employeeToUpdate, [FromBody] EmployeeModel employeeFinded) {
        throw new NotImplementedException();
    }
}