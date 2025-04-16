public class CreateRepository {
    public async static void writeRepository(string path, string name) {
        string parameter = $"{name.ToLower()}";
        string upName = name.ToUpper()[0] + name.Substring(1);

        File.WriteAllTextAsync(path,
        "using Microsoft.EntityFrameworkCore;\n" +

        $"public class {upName}Repository : I{upName}Repository" + "{\n" +
        $"  private readonly Db _db;\n" +

        $"  public {upName}Repository(Db db)" + "{\n" +
        $"   _db = db;\n" +
        "   }\n" +
        "}"
        );
    }
}