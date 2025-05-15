public class EmployeeModel : UserModel {
  public required string Position { get; set; }
  public required string HireDate { get; set; }
  public required float Salary { get; set; }
  public required string Shift { get; set; }

  public EmployeeModel() {
  }

  public EmployeeModel(string cpf, string name, string email, string password,
                       string position, string hireDate, float salary, string shift)
      : base(cpf, name, email, password) {
    Position = position;
    HireDate = hireDate;
    Salary = salary;
    Shift = shift;
  }
}
