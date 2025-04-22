using System.ComponentModel.DataAnnotations.Schema;

public class PhoneModel {

  public int Id { get; set; }
  public string Number { get; set; }

  [ForeignKey("User")]
  public string Cpf { get; set; }

  public UserModel User { get; set; }

  public PhoneModel(string number, string cpf) {
    Number = number;
    Cpf = cpf;
  }

  public PhoneModel() { }
}