public class PhoneModel {

  public int? Id { get; set; }
  public string? Number { get; set; }
  public string? Cpf { get; set; }
  public PhoneModel(string? number, string? cpf) {
    Number = number;
    Cpf = cpf;
  }
}