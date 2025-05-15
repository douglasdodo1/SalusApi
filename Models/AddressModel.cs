using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class AddressModel {


  [Key]
  public string Cep { get; set; }
  public int RuaId { get; set; }
  public string Complemento { get; set; }

  public AddressModel(string cep, int ruaId, string complemento) {
    Cep = cep;
    RuaId = ruaId;
    Complemento = complemento;
  }
}