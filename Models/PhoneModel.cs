using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class PhoneModel {

  [Key]
  public int Id { get; set; }
  public required string Number { get; set; }

  [ForeignKey("User")]
  public string? Cpf { get; set; }

  public UserModel? User { get; set; }

  public PhoneModel(string number, string cpf) {
    Number = number;
    Cpf = cpf;
  }

}