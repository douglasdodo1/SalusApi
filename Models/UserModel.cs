public class UserModel {
    public string? Cpf { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public UserModel(string? cpf, string? name, string? email, string? password) {
        Cpf = cpf;
        Name = name;
        Email = email;
        Password = password;
    }
}