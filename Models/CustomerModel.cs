public class CustomerModel : UserModel {
  public int Id { get; set; }
  public CustomerModel(string cpf, string name, string email, string password)
         : base(cpf, name, email, password) {
  }
}