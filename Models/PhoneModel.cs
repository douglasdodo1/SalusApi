using System.ComponentModel.DataAnnotations.Schema;

public class PhoneModel {

  public required int Id { get; set; }
  public required string Number { get; set; }

  [ForeignKey("User")]
  public required string Cpf { get; set; }

  public required UserModel User { get; set; }

  public PhoneModel(string number, string cpf) {
    Number = number;
    Cpf = cpf;
  }

  public PhoneModel() { }
}