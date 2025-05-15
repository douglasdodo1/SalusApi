using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class EmployeeRepository : IEmployeeRepository {
    private readonly Db _db;
    public EmployeeRepository(Db db) {
        _db = db;
    }

    public async Task<EmployeeModel> Add([FromBody] EmployeeModel employee) {
        EmployeeModel createdEmployee = (await _db.Employee.AddAsync(employee)).Entity;
        await _db.SaveChangesAsync();
        return createdEmployee;
    }

    public async Task<EmployeeModel> FindByCpf(string cpf) {
        EmployeeModel? employee = await _db.Employee.FindAsync(cpf);
        return employee;
    }


    public async Task<List<EmployeeModel>> FindAll() {
        List<EmployeeModel> employeeList = await _db.Employee.ToListAsync();
        return employeeList;
    }

    public async Task<EmployeeModel> Update([FromBody] EmployeeModel employeeToUpdate, [FromBody] EmployeeModel employeeFinded) {
        employeeFinded.Name = employeeToUpdate.Name;
        employeeFinded.Email = employeeToUpdate.Email;
        employeeFinded.Password = employeeToUpdate.Password;
        employeeFinded.Cpf = employeeToUpdate.Cpf;
        employeeFinded.HireDate = employeeToUpdate.HireDate;
        employeeFinded.Position = employeeToUpdate.Position;
        employeeFinded.Shift = employeeToUpdate.Shift;
        employeeFinded.Position = employeeToUpdate.Position;
        employeeFinded.Salary = employeeToUpdate.Salary;


        await _db.SaveChangesAsync();
        return employeeToUpdate;
    }

    public async Task<EmployeeModel> Remove([FromBody] EmployeeModel employee) {
        EmployeeModel employeeDeleted = _db.Employee.Remove(employee).Entity;
        await _db.SaveChangesAsync();
        return employeeDeleted;
    }


}