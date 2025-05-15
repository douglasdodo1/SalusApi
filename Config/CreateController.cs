public class CreateController {
    public async static void writeController(string path, string name) {
        string parameter = $"{name.ToLower()}";
        string upName = name.ToUpper()[0] + name.Substring(1);

        await File.WriteAllTextAsync(path,
        "using Microsoft.AspNetCore.Mvc;\n" +

        "\n[Controller]\n" +
        "[Route(\"" + upName + "\")]\n" +

        $"public class {upName}Controller : I{upName}Controller" + "{\n" +
        $"  private readonly {name}Service _{parameter}Service;\n" +

        $"  public {upName}Controller({upName}Service {parameter}Service)" + "{\n" +
        $"    _{parameter}Service = {parameter}Service;\n" +
        "   }" +
        "}"
        );
    }
}