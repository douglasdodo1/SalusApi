public class CreateService {
    public async static void writeService(string path, string name) {
        string parameter = $"{name.ToLower()}";
        string upName = name.ToUpper()[0] + name.Substring(1);

        File.WriteAllTextAsync(path,
        $"public class {upName}Service : I{upName}Service" + "{\n" +
        $"  private readonly {upName}Repository _{parameter}Repository;\n" +

        $"  public {upName}Service({upName}Repository {parameter}Repository)" + "{\n" +
        $"    _{parameter}Repository = {parameter}Repository;\n" +
        "   }\n" +
        "}"
        );
    }
}