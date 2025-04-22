using System.ComponentModel.DataAnnotations;

public class UserModel {

    [Key]
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<PhoneModel>? Phones { get; set; } = new List<PhoneModel>();

    public UserModel(string cpf, string name, string email, string password) {
        Cpf = cpf;
        Name = name;
        Email = email;
        Password = password;
    }

    public UserModel() { }
}