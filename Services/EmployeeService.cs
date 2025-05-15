using Microsoft.AspNetCore.Mvc;

public class EmployeeService : IEmployeeService {
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository) {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeModel> Add([FromBody] EmployeeModel employee) {
        var userValidator = new UserValidator();
        var userValitadorResult = userValidator.Validate(employee);
        string errors = string.Join("; ", userValitadorResult.Errors.Select(e => e.ErrorMessage));

        if (!userValitadorResult.IsValid) {
            throw new ArgumentException(errors);
        }

        var employeeValidator = new EmployeeValidator();
        var employeeValidatorResult = employeeValidator.Validate(employee);
        errors = string.Join("; ", employeeValidatorResult.Errors.Select(e => e.ErrorMessage));

        if (!employeeValidatorResult.IsValid) {
            throw new ArgumentException(errors);
        }

        EmployeeModel findedEmployee = await _employeeRepository.FindByCpf(employee.Cpf);
        if (findedEmployee != null) {
            throw new ArgumentException("Employee already exists");
        }

        EmployeeModel createdEmployee = await _employeeRepository.Add(employee);
        return createdEmployee;
    }

    public async Task<EmployeeModel> FindByCpf(string cpf) {
        EmployeeModel findedEmployee = await _employeeRepository.FindByCpf(cpf);
        if (findedEmployee == null) {
            throw new KeyNotFoundException("Employee not found");
        }
        return findedEmployee;
    }

    public async Task<List<EmployeeModel>> FindAll() {
        List<EmployeeModel> employeeList = await _employeeRepository.FindAll();
        return employeeList;
    }

    public async Task<EmployeeModel> Update(string cpf, [FromBody] EmployeeModel employee) {
        var userValidator = new UserValidator(true);
        var userValitadorResult = userValidator.Validate(employee);
        string errors = string.Join("; ", userValitadorResult.Errors.Select(e => e.ErrorMessage));

        if (!userValitadorResult.IsValid) {
            throw new ArgumentException(errors);
        }

        var employeeValidator = new EmployeeValidator();
        var employeeValidatorResult = employeeValidator.Validate(employee);
        errors = string.Join("; ", employeeValidatorResult.Errors.Select(e => e.ErrorMessage));

        if (!employeeValidatorResult.IsValid) {
            throw new ArgumentException(errors);
        }

        EmployeeModel findedEmployee = await FindByCpf(cpf);
        EmployeeModel updatedEmployee = await _employeeRepository.Update(employee, findedEmployee);

        if (updatedEmployee == null) {
            throw new KeyNotFoundException("Employee not found");
        }
        return updatedEmployee;
    }

    public Task<EmployeeModel> Remove(string cpf) {
        throw new NotImplementedException();
    }
}